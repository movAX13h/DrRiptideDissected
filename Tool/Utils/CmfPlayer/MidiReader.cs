/* srtuss's CMF player */

using System;
using System.IO;

namespace CmfPlayer
{
    class MidiEvent
    {
        public int delta;
        public Type type;
        public int channel, p1, p2;
        public int metaType;
        public byte[] data;

        public enum Type
        {
            Invalid = 0,
            NoteOff = 0x8,
            NoteOn = 0x9,
            NoteAftertouch = 0xA,
            Controller = 0xB,
            ProgramChange = 0xC,
            ChannelAftertouch = 0xD,
            PitchBend = 0xE,
            SysEx = 0xF
        }

        public override string ToString()
        {
            return delta + " " + type + " " + channel;
        }
    }

    class MidiReader
    {
        bool end = false;
        int rstatus = -1;
        Stream f;
        public bool End { get { return end; } }
        public MidiReader(Stream f) { this.f = f; }

        static int RVlen(Stream f)
        {
            var v = f.ReadByte();
            if(v >= 128)
                v = f.ReadByte() + ((v - 128) << 7);
            if(v >= 16384)
                v = f.ReadByte() + ((v - 16384) << 7);
            return v;
        }

        public MidiEvent ReadEvent()
        {
            var ev = new MidiEvent();
            ev.delta = RVlen(f);
            int b = f.ReadByte();
            int type;
            if(b < 128)
            {
                if(rstatus == -1)
                    throw new Exception("read error");
                type = rstatus;
                f.Position--;
            }
            else
            {
                type = b;
                rstatus = type;
            }
            switch(type & 0xF0)
            {
                case 0x80:
                case 0x90:
                case 0xA0:
                case 0xB0:
                case 0xE0:
                    ev.channel = (type & 0xF);
                    type >>= 4;
                    ev.p1 = f.ReadByte();
                    ev.p2 = f.ReadByte();
                    break;
                case 0xC0:
                case 0xD0:
                    ev.channel = type & 0xF;
                    type >>= 4;
                    ev.p1 = f.ReadByte();
                    break;
                case 0xF0:
                    if(type == 0xFF)
                    {
                        ev.metaType = f.ReadByte();
                        if(ev.metaType == 0x2F)
                            end = true;
                    }
                    type >>= 4;
                    ev.data = new byte[RVlen(f)];
                    f.Read(ev.data, 0, ev.data.Length);
                    break;
                default:
                    throw new Exception("bad event x" + type.ToString("X2").ToUpper());
            }
            ev.type = (MidiEvent.Type)type;
            return ev;
        }
    }
}