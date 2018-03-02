using System.IO;

namespace riptide.Utils
{
    class RiffWave
    {
        // write a RIFF WAVE (wav) file to a stream
        public static void Write(Stream f, byte[] data, int nChannels, int nBitsPerSample, int nSamplesPerSec, int formatTag)
        {
            int nBlockAlign = (nChannels * nBitsPerSample + 7) / 8;
            int nAvgBytesPerSec = nSamplesPerSec * nBlockAlign;
            int flen = data.Length + 36;
            int dlen = data.Length;
            byte[] header = new byte[] {
                (byte)'R', (byte)'I', (byte)'F', (byte)'F', (byte)flen, (byte)(flen >> 8), (byte)(flen >> 16), (byte)(flen >> 24),
                (byte)'W', (byte)'A', (byte)'V', (byte)'E',
                (byte)'f', (byte)'m', (byte)'t', (byte)' ', 16, 0, 0, 0,
                (byte)formatTag, (byte)(formatTag >> 8),
                (byte)nChannels, (byte)(nChannels >> 8),
                (byte)nSamplesPerSec, (byte)(nSamplesPerSec >> 8), (byte)(nSamplesPerSec >> 16), (byte)(nSamplesPerSec >> 24),
                (byte)nAvgBytesPerSec, (byte)(nAvgBytesPerSec >> 8), (byte)(nAvgBytesPerSec >> 16), (byte)(nAvgBytesPerSec >> 24),
                (byte)nBlockAlign, (byte)(nBlockAlign >> 8),
                (byte)nBitsPerSample, (byte)(nBitsPerSample >> 8),
                (byte)'d', (byte)'a', (byte)'t', (byte)'a', (byte)dlen, (byte)(dlen >> 8), (byte)(dlen >> 16), (byte)(dlen >> 24)
            };
            f.Write(header, 0, header.Length);
            f.Write(data, 0, data.Length);
            f.Close();
        }
    }
}
