/* srtuss's CMF player */

using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace CmfPlayer
{
    using WORD = UInt16;
    using DWORD = UInt32;
    using HRESULT = UInt32;
    using REFERENCE_TIME = Int64;
    using UINT32 = UInt32;

    enum EDataFlow
    {
        eRender = 0,
        eCapture = (eRender + 1),
        eAll = (eCapture + 1),
        EDataFlow_enum_count = (eAll + 1)
    }
    enum ERole
    {
        eConsole = 0,
        eMultimedia = (eConsole + 1),
        eCommunications = (eMultimedia + 1),
        ERole_enum_count = (eCommunications + 1)
    }
    enum AUDCLNT_SHAREMODE
    {
        SHARED,
        EXCLUSIVE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WAVEFORMATEX
    {
        public short wFormatTag;         /* format type */
        public short nChannels;          /* number of channels (i.e. mono, stereo...) */
        public int nSamplesPerSec;    /* sample rate */
        public int nAvgBytesPerSec;   /* for buffer estimation */
        public short nBlockAlign;        /* block size of data */
        public short wBitsPerSample;     /* number of bits per sample of mono data */
        public short cbSize;             /* the count in bytes of the size of */
                                        /* extra information (after cbSize) */
    }

    [ComImport, Guid("F294ACFC-3146-4483-A7BF-ADDCA7C260E2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IAudioRenderClient
    {
        HRESULT GetBuffer(UINT32 NumFramesRequested, out IntPtr ppData);
        HRESULT ReleaseBuffer(UINT32 NumFramesWritten, DWORD dwFlags);
    }

    [ComImport, Guid("1CB9AD4C-DBFA-4c32-B178-C2F568A703B2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IAudioClient
    {
        HRESULT Initialize(AUDCLNT_SHAREMODE ShareMode, DWORD StreamFlags, REFERENCE_TIME hnsBufferDuration, REFERENCE_TIME hnsPeriodicity, ref WAVEFORMATEX pFormat, IntPtr AudioSessionGuid);
        HRESULT GetBufferSize(out UINT32 pNumBufferFrames);
        HRESULT GetStreamLatency(out REFERENCE_TIME phnsLatency);
        HRESULT GetCurrentPadding(out UINT32 pNumPaddingFrames);
        HRESULT IsFormatSupported(AUDCLNT_SHAREMODE ShareMode, ref WAVEFORMATEX pFormat, out IntPtr ppClosestMatch);
        HRESULT GetMixFormat(out IntPtr ppDeviceFormat);
        HRESULT GetDevicePeriod(out REFERENCE_TIME phnsDefaultDevicePeriod, out REFERENCE_TIME phnsMinimumDevicePeriod);
        HRESULT Start();
        HRESULT Stop();
        HRESULT Reset();
        HRESULT SetEventHandle(IntPtr eventHandle);
        HRESULT GetService(ref Guid riid, out IntPtr ppv);
    }

    [ComImport, Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IMMDevice
    {
        HRESULT Activate(ref Guid iid, DWORD dwClsCtx, IntPtr pActivationParams, out IntPtr ppInterface);
        
        // ...
    }

    [ComImport, Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface MMDeviceEnumerator
    {
        HRESULT EnumAudioEndpoints(EDataFlow dataFlow, DWORD dwStateMask, out IntPtr ppDevices);
        HRESULT GetDefaultAudioEndpoint(EDataFlow dataFlow, ERole role, out IMMDevice ppEndpoint);
        
        // ...
    }

    static class Wasapi
    {
        [DllImport("ole32")]
        public static extern int CoCreateInstance(ref Guid clsid,
           IntPtr inner,
           uint context,
           ref Guid uuid,
           out IntPtr rReturnedComObject);

        [DllImport("ole32")]
        public static extern void CoTaskMemFree(IntPtr pv);

        static MMDeviceEnumerator CreateDeviceEnumerator()
        {
            var clsid = Guid.Parse("BCDE0395-E52F-467C-8E3D-C4579291692E");
            var iid = typeof(MMDeviceEnumerator).GUID;

            const uint CLSCTX_ALL = 0x17;
            CoCreateInstance(
                ref clsid,
                (IntPtr)0,
                CLSCTX_ALL,
                ref iid,
                out IntPtr pMMDeviceEnumerator);

            return (MMDeviceEnumerator)Marshal.GetObjectForIUnknown(pMMDeviceEnumerator);
        }
        public static IMMDevice AudioEndpoint
        {
            get
            {
                CreateDeviceEnumerator().GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eConsole, out IMMDevice endpoint);
                return endpoint;
            }
        }

    }

    public class AudioClientInfo
    {
        public REFERENCE_TIME minimumPeriod;
        public REFERENCE_TIME defaultPeriod;
    }
    
    public enum FormatType
    {
        UInt8,
        Int16,
        Float32
    }

    public class WasapiAudioRenderClient
    {
        IAudioClient audioClient;
        IAudioRenderClient audioRenderClient;
        public EventWaitHandle WaitEvent { private set; get; }
        uint numBufferFrames;
        public string ErrorMessage { private set; get; } = "";
        public bool IsOpen { private set; get; }
        int blockAlign;
        long tickStart = 0;
        public int SampleRate { private set; get; }

        public int AvailableBytes
        {
            get
            {
                if(!IsOpen)
                    throw new Exception("AudioRenderClient is not open!");

                audioClient.GetCurrentPadding(out DWORD numPaddingFrames);
                return (int)(numBufferFrames - numPaddingFrames) * blockAlign;
            }
        }

        public void Write(byte[] data, int offset, int num)
        {
            if(!IsOpen)
                throw new Exception("AudioRenderClient is not open!");
            if(num > 0)
            {
                int numFrames = num / blockAlign;
                audioRenderClient.GetBuffer((DWORD)numFrames, out IntPtr pData);
                Marshal.Copy(data, offset, pData, num);
                audioRenderClient.ReleaseBuffer((DWORD)numFrames, 0);
            }
        }

        public WAVEFORMATEX MixerFormat
        {
            get
            {
                var iid = typeof(IAudioClient).GUID;

                const uint CLSCTX_ALL = 0x17;
                Wasapi.AudioEndpoint.Activate(ref iid, CLSCTX_ALL, (IntPtr)0, out IntPtr pAudioClient);

                var audioClient = (IAudioClient)Marshal.GetObjectForIUnknown(pAudioClient);

                audioClient.GetMixFormat(out IntPtr ppDeviceFormat);

                var wfmt = new WAVEFORMATEX
                {
                    wFormatTag = Marshal.ReadInt16(ppDeviceFormat, 0),
                    nChannels = Marshal.ReadInt16(ppDeviceFormat, 2),
                    nSamplesPerSec = Marshal.ReadInt32(ppDeviceFormat, 4),
                    nAvgBytesPerSec = Marshal.ReadInt32(ppDeviceFormat, 8),
                    nBlockAlign = Marshal.ReadInt16(ppDeviceFormat, 12),
                    wBitsPerSample = Marshal.ReadInt16(ppDeviceFormat, 14)
                };

                Wasapi.CoTaskMemFree(ppDeviceFormat);

                return wfmt;
            }
        }

        public AudioClientInfo Info
        {
            get
            {
                var iid = typeof(IAudioClient).GUID;

                const uint CLSCTX_ALL = 0x17;
                Wasapi.AudioEndpoint.Activate(ref iid, CLSCTX_ALL, (IntPtr)0, out IntPtr pAudioClient);

                var audioClient = (IAudioClient)Marshal.GetObjectForIUnknown(pAudioClient);

                var info = new AudioClientInfo();
                audioClient.GetDevicePeriod(out info.defaultPeriod, out info.minimumPeriod);
                return info;
            }
        }

        public double CurrentTime
        {
            get
            {
                return new TimeSpan(DateTime.Now.Ticks - tickStart).TotalSeconds;
            }
        }

        public bool Open(REFERENCE_TIME bufferDuration, int nChannels, int nSamplesPerSec, FormatType format)
        {
            try
            {
                if(IsOpen)
                    throw new Exception("AudioRenderClient is already open!");

                var iid = typeof(IAudioClient).GUID;

                const uint CLSCTX_ALL = 0x17;
                Wasapi.AudioEndpoint.Activate(ref iid, CLSCTX_ALL, (IntPtr)0, out IntPtr pAudioClient);

                audioClient = (IAudioClient)Marshal.GetObjectForIUnknown(pAudioClient);

                audioClient.GetDevicePeriod(out REFERENCE_TIME defaultPeriod, out REFERENCE_TIME minimumPeriod);

                int formatTag = 1;
                int smpBits = 8;
                switch(format)
                {
                    case FormatType.UInt8:
                        smpBits = 8;
                        break;
                    case FormatType.Int16:
                        smpBits = 16;
                        break;
                    case FormatType.Float32:
                        formatTag = 3;
                        smpBits = 32;
                        break;
                }

                var wfmt = new WAVEFORMATEX {
                    wFormatTag = (short)formatTag,
                    nChannels = (short)nChannels,
                    nSamplesPerSec = nSamplesPerSec,
                    nBlockAlign = (short)((nChannels * smpBits + 7) / 8),
                    wBitsPerSample = (short)smpBits
                };

                wfmt.nAvgBytesPerSec = wfmt.nSamplesPerSec * wfmt.nBlockAlign;

                DWORD streamFlags = 0x00040000;
                audioClient.Initialize(AUDCLNT_SHAREMODE.SHARED, streamFlags, bufferDuration, 0, ref wfmt, (IntPtr)0);

                WaitEvent = new EventWaitHandle(false, EventResetMode.AutoReset);

                audioClient.SetEventHandle(WaitEvent.Handle);
                audioClient.GetBufferSize(out numBufferFrames);

                iid = typeof(IAudioRenderClient).GUID;
                audioClient.GetService(iid, out IntPtr pAudioRenderClient);

                audioRenderClient = (IAudioRenderClient)Marshal.GetObjectForIUnknown(pAudioRenderClient);

                IsOpen = true;
                blockAlign = wfmt.nBlockAlign;
                SampleRate = wfmt.nSamplesPerSec;

                return true;
            }
            catch(Exception e)
            {
                ErrorMessage = e.Message;
                return false;
            }
        }

        public void Start()
        {
            audioClient.Start();
            tickStart = DateTime.Now.Ticks;
        }

        public void Stop()
        {
            audioClient.Stop();
        }
    }
}