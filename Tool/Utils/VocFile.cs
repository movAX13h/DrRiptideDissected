// based upon: http://www.shikadi.net/moddingwiki/VOC_Format

using System;
using System.IO;
using System.Text;

namespace riptide.Utils
{
    class VocFile
    {
        public enum Format
        {
            Pcm8BitUnsigned,
            Adpcm4to8,
            Adpcm3to8,
            Adpcm2to8,
            Pcm16BitSigned,
            Alaw1,
            Alaw2,
            Adpcm4to16
        }
        public Format format;
        public byte[] data;
        public int samplerate;

        public double SecDuration
        {
            get
            {
                switch (format)
                {
                    case Format.Pcm8BitUnsigned:
                        return (double)data.Length / samplerate;
                    case Format.Pcm16BitSigned:
                        return (double)(data.Length / 2) / samplerate;
                }
                return 0;
            }
        }

        static string RString(Stream f, int n)
        {
            var b = new byte[n];
            f.Read(b, 0, n);
            return Encoding.ASCII.GetString(b);
        }

        static int RWord(Stream f)
        {
            return f.ReadByte() + f.ReadByte() * 256;
        }

        static int RWord24(Stream f)
        {
            return f.ReadByte() + RWord(f) * 256;
        }

        public VocFile(string filename)
        {
            init(File.OpenRead(filename));
        }

        public VocFile(byte[] data)
        {
            init(new MemoryStream(data));
        }

        private void init(Stream s)
        {
            if (RString(s, 19) != "Creative Voice File")
                throw new Exception("bad file");

            if (s.ReadByte() != 0x1A)
                throw new Exception("bad file");

            int hdrSz = RWord(s);
            if (hdrSz != 26)
                throw new Exception("bad file");

            int version = RWord(s);
            int versionChecksum = RWord(s);

            while (s.Position < s.Length)
            {
                int blockType = s.ReadByte();
                if (blockType == 0)
                    break;
                int blockSize = RWord24(s);
                var next = s.Position + blockSize;

                switch (blockType)
                {
                    case 1: // sound data with type
                        int freqDiv = s.ReadByte();
                        format = (Format)s.ReadByte();
                        samplerate = 1000000 / (256 - freqDiv);
                        data = new byte[next - s.Position];
                        s.Read(data, 0, data.Length);
                        break;
                    case 2: // sound data without type
                        // TD: implement
                        break;
                    case 3: // silence
                        // TD: implement
                        break;
                    case 4: // marker
                        // TD: implement
                        break;
                    case 5: // text
                        // TD: implement
                        break;
                    case 6: // repeat start
                        // TD: implement
                        break;
                    case 7: // repeat end
                        // TD: implement
                        break;
                    case 8: // extra information
                        // TD: implement
                        break;
                    case 9: // sound data (new format)
                        // TD: implement
                        break;
                    default:
                        Console.WriteLine("Warning: unrecognized VOC block-type \"" + blockType + "\"");
                        break;
                }

                s.Position = next;
            }

            s.Close();
        }

        public MemoryStream ToWavStream()
        {
            return new MemoryStream(ToWav());
        }

        public byte[] ToWav()
        {
            var wavMem = new byte[data.Length + 44];

            switch(format)
            {
                case Format.Pcm8BitUnsigned:
                    RiffWave.Write(new MemoryStream(wavMem, true), data, 1, 8, samplerate, 1);
                    break;

                case Format.Pcm16BitSigned:
                    RiffWave.Write(new MemoryStream(wavMem, true), data, 1, 16, samplerate, 1);
                    break;

                default:
                    RiffWave.Write(new MemoryStream(wavMem, true), new byte[] { 0, 0 }, 1, 16, 44100, 1); // create a silent dummy-sound
                    break;
            }

            return wavMem;
        }
    }

}