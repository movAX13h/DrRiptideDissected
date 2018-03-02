/* srtuss's CMF player */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// http://www.shikadi.net/moddingwiki/CMF_Format

namespace CmfPlayer
{
    class Cmf
    {
        public string version;
        public int ticksPerQuater;
        public int ticksPerSecond;
        public int tempoBpm;
        public string title;
        public string composer;
        public string remarks;

        public class Instrument
        {
            public int iModChar;
            public int iCarChar;
            public int iModScale;
            public int iCarScale;
            public int iModAttack;
            public int iCarAttack;
            public int iModSustain;
            public int iCarSustain;
            public int iModWaveSel;
            public int iCarWaveSel;
            public int iFeedback;
        };

        public List<Instrument> instruments;
        public byte[] mididata;

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

        public static bool Detect(string filename)
        {
            var f = File.OpenRead(filename);
            bool ret = RString(f, 4) == "CTMF";
            f.Close();
            return ret;
        }

        public Cmf(string filename)
        {
            if (!File.Exists(filename)) throw new Exception("cmf file does not exist");

            Stream s = File.OpenRead(filename);
            processStream(s);
        }

        public Cmf(byte[] bytes)
        {
            Stream s = new MemoryStream(bytes);
            processStream(s);
        }

        private void processStream(Stream s)
	    {
            if (RString(s, 4) != "CTMF") throw new Exception("bad file");
		    int vminor = s.ReadByte();
            int vmajor = s.ReadByte();
            version = vmajor + "." + vminor;
            int offsetInstruments = RWord(s);
            int offsetMusic = RWord(s);
            ticksPerQuater = RWord(s);
            ticksPerSecond = RWord(s);
            int offsetTitle = RWord(s);
            int offsetComposer = RWord(s);
            int offsetRemarks = RWord(s);

            var usedChannels = new byte[16];
            s.Read(usedChannels, 0, 16);
            
            int instrumentCount = 16;
            if (vmajor == 1 && vminor == 0) instrumentCount = s.ReadByte();
            else if (vmajor == 1 && vminor == 1)
            {
                instrumentCount = RWord(s);
                tempoBpm = RWord(s);
            }

            instruments = new List<Instrument>(instrumentCount);
            for (int i = 0; i < instrumentCount; ++i)
            {
                instruments.Add(new Instrument
                {
                    iModChar = s.ReadByte(),
                    iCarChar = s.ReadByte(),
                    iModScale = s.ReadByte(),
                    iCarScale = s.ReadByte(),
                    iModAttack = s.ReadByte(),
                    iCarAttack = s.ReadByte(),
                    iModSustain = s.ReadByte(),
                    iCarSustain = s.ReadByte(),
                    iModWaveSel = s.ReadByte(),
                    iCarWaveSel = s.ReadByte(),
                    iFeedback = s.ReadByte()
                });
                s.Position += 5; // zero padding
            }

            s.Position = offsetMusic;
            mididata = new byte[s.Length - s.Position];
            s.Read(mididata, 0, mididata.Length);

            if (offsetTitle > 0)
            {
                s.Position = offsetTitle;
                throw new NotImplementedException();
            }
            else
                title = "";

            if (offsetComposer > 0)
            {
                s.Position = offsetComposer;
                throw new NotImplementedException();
            }
            else
                composer = "";

            if (offsetRemarks > 0)
            {
                s.Position = offsetRemarks;
                throw new NotImplementedException();
            }
            else
                remarks = "";


            s.Close();
        }
    }
}
