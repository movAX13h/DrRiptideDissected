/* srtuss's CMF player */

using System;
using System.IO;
using System.Threading;

namespace CmfPlayer
{    
    class PlayerCore
    {
        public bool End { get; private set; } = false;
        int sampleRate;
        Cmf cmfFile;
        MidiReader mr;
        Adlib0 adlib;

        public delegate void ChannelActivity_T(double time, int channel, float velocity);
        public ChannelActivity_T ChannelActivity;

        public PlayerCore(int sampleRate, Cmf cmfFile)
        {
            this.sampleRate = sampleRate;
            this.cmfFile = cmfFile;
            mr = new MidiReader(new MemoryStream(cmfFile.mididata));
            adlib = new Adlib0(sampleRate, 2);
            for(int i = 0; i < channels.Length; ++i)
                channels[i] = new Channel();
        }

        class Channel
        {
            public int regb;
            public int midiNote = -1;
        }
        Channel[] channels = new Channel[16];
        MidiEvent miv = null;
        int bytesLeft = 0;

        bool rhythmMode = false;
        int regbd = 0;
        int bytesPerSample = 4;
        double time = 0;
        public double Time
        {
            get
            {
                return time;
            }
        }

        public void Process(byte[] buffer, int num)
        {
            for(int pos = 0, td; pos < num; pos += td, bytesLeft -= td)
            {
                while(bytesLeft == 0)
                {
                    if(miv != null)
                        Dispatch(miv);

                    if(mr.End)
                    {
                        End = true;
                        bytesLeft = sampleRate * bytesPerSample;
                    }
                    else
                    {
                        miv = mr.ReadEvent();
                        bytesLeft = (miv.delta * sampleRate / cmfFile.ticksPerSecond) * bytesPerSample;
                    }
                }

                td = Math.Min(num - pos, bytesLeft);
                adlib.GetSamples(buffer, pos, td);

                time += (double)(td / bytesPerSample) / sampleRate;
            }
        }

        void Dispatch(MidiEvent ev)
        {
            switch(miv.type)
            {
                case MidiEvent.Type.Controller:
                    switch(ev.p1)
                    {
                        case 0x63: // depth control
                                   // TD: implement
                            break;
                        case 0x66: // song marker
                                   // This can be used to notify the music player that a certain point
                                   // in a song has been reached, or to trigger some kind of action in
                                   // time with the music.
                            break;
                        case 0x67: // control rhythm mode
                            rhythmMode = ev.p2 > 0;

                            if(rhythmMode)
                            {
                                regbd = 1 << 5;
                                adlib.Poke(0xBD, regbd);
                            }
                            else
                            {
                                regbd = 0;
                                adlib.Poke(0xBD, regbd);
                            }
                            break;
                        case 0x68: // transpose up
                                   // TD: implement
                            break;
                        case 0x69: // transpose down
                                   // TD: implement
                            break;
                    }
                    break;

                case MidiEvent.Type.ProgramChange:
                    if(rhythmMode && ev.channel >= 11)
                        LoadRhythm(adlib, ev.channel, cmfFile.instruments[ev.p1]);
                    else
                        LoadInstrument(adlib, ev.channel, cmfFile.instruments[ev.p1]);
                    break;

                case MidiEvent.Type.NoteOn:
                    if(ev.p2 > 0)
                    {
                        if(channels[ev.channel].midiNote != -1)
                            SetGate(ev.channel, false);

                        channels[ev.channel].midiNote = ev.p1;
                        

                        if(rhythmMode && ev.channel >= 11)
                        {
                            if(ev.channel == 11) // bassdrum
                                SetChannelPitch(6, ev.p1);

                            SetRhythmGate(ev.channel, true);
                            SetRhythmVelocity(ev.channel, ev.p2 / 127f);

                            switch(ev.channel)
                            {
                                case 11: // bassdrum
                                    ChannelActivity?.Invoke(time, 6, ev.p2 / 127f);
                                    break;
                                case 12: // snare
                                case 13: // tom
                                    ChannelActivity?.Invoke(time, 7, ev.p2 / 127f);
                                    break;
                                case 14: // cymbal
                                case 15: // hat
                                    ChannelActivity?.Invoke(time, 8, ev.p2 / 127f);
                                    break;
                            }
                            
                        }
                        else
                        {
                            SetChannelPitch(ev.channel, ev.p1);
                            SetChannelVelocity(ev.channel, ev.p2 / 127f);
                            SetGate(ev.channel, true);

                            ChannelActivity?.Invoke(time, ev.channel, ev.p2 / 127f);
                        }
                    }
                    else
                    {
                        if(channels[ev.channel].midiNote == ev.p1)
                        {
                            channels[ev.channel].midiNote = -1;

                            if(rhythmMode && ev.channel >= 11)
                                SetRhythmGate(ev.channel, false);
                            else
                            {
                                SetGate(ev.channel, false);
                            }
                        }
                    }
                    break;
                case MidiEvent.Type.NoteOff:
                    if(channels[ev.channel].midiNote == ev.p1)
                    {
                        if(rhythmMode && ev.channel >= 11)
                            SetRhythmGate(ev.channel, false);
                        else
                        {
                            SetGate(ev.channel, false);
                        }
                    }
                    break;
            }
        }

        void SetGate(int cmfChannel, bool value)
        {
            if(value)
            {
                channels[cmfChannel].regb |= 1 << 5;
                adlib.Poke(0xB0 + cmfChannel, channels[cmfChannel].regb);
            }
            else
            {
                channels[cmfChannel].regb &= ~(1 << 5);
                adlib.Poke(0xB0 + cmfChannel, channels[cmfChannel].regb);
            }
        }


        void SetRhythmGate(int cmfChannel, bool value)
        {
            if(value)
            {
                switch(cmfChannel)
                {
                    case 11: // bassdrum
                        regbd |= 1 << 4; adlib.Poke(0xBD, regbd);
                        break;
                    case 12: // snare
                        regbd |= 1 << 3; adlib.Poke(0xBD, regbd);
                        break;
                    case 13: // tom
                        regbd |= 1 << 2; adlib.Poke(0xBD, regbd);
                        break;
                    case 14: // cymbal
                        regbd |= 1 << 1; adlib.Poke(0xBD, regbd);
                        break;
                    case 15: // hihat
                        regbd |= 1 << 0; adlib.Poke(0xBD, regbd);
                        break;
                }
            }
            else
            {
                switch(cmfChannel)
                {
                    case 11: // bassdrum
                        regbd &= ~(1 << 4); adlib.Poke(0xBD, regbd);
                        break;
                    case 12: // snare
                        regbd &= ~(1 << 3); adlib.Poke(0xBD, regbd);
                        break;
                    case 13: // tom
                        regbd &= ~(1 << 2); adlib.Poke(0xBD, regbd);
                        break;
                    case 14: // cymbal
                        regbd &= ~(1 << 1); adlib.Poke(0xBD, regbd);
                        break;
                    case 15: // hihat
                        regbd &= ~(1 << 0); adlib.Poke(0xBD, regbd);
                        break;
                }
            }
        }

        static void LoadInstrument(Adlib0 adlib, int channel, Cmf.Instrument instrument)
        {
            var optbl = new int[] { 0, 1, 2, 8, 9, 10, 16, 17, 18 };
            adlib.Poke(0x20 + optbl[channel], instrument.iModChar);
            adlib.Poke(0x23 + optbl[channel], instrument.iCarChar);
            adlib.Poke(0x40 + optbl[channel], instrument.iModScale);
            adlib.Poke(0x43 + optbl[channel], instrument.iCarScale);
            adlib.Poke(0x60 + optbl[channel], instrument.iModAttack);
            adlib.Poke(0x63 + optbl[channel], instrument.iCarAttack);
            adlib.Poke(0x80 + optbl[channel], instrument.iModSustain);
            adlib.Poke(0x83 + optbl[channel], instrument.iCarSustain);
            adlib.Poke(0xE0 + optbl[channel], instrument.iModWaveSel);
            adlib.Poke(0xE3 + optbl[channel], instrument.iCarWaveSel);
            adlib.Poke(0xC0 + channel, instrument.iFeedback);
        }

        static void LoadRhythm(Adlib0 adlib, int cmfChannel, Cmf.Instrument instrument)
        {
            int i, j;
            switch(cmfChannel)
            {
                case 11: // bassdrum
                    i = 16;
                    j = 19;
                    adlib.Poke(0x20 + i, instrument.iModChar);
                    adlib.Poke(0x40 + i, instrument.iModScale);
                    adlib.Poke(0x60 + i, instrument.iModAttack);
                    adlib.Poke(0x80 + i, instrument.iModSustain);
                    adlib.Poke(0xE0 + i, instrument.iModWaveSel);
                    adlib.Poke(0x20 + j, instrument.iCarChar);
                    adlib.Poke(0x40 + j, instrument.iCarScale);
                    adlib.Poke(0x60 + j, instrument.iCarAttack);
                    adlib.Poke(0x80 + j, instrument.iCarSustain);
                    adlib.Poke(0xE0 + j, instrument.iCarWaveSel);
                    adlib.Poke(0xC0 + 6, instrument.iFeedback);

                    break;
                case 12: // snare
                    i = 20;
                    adlib.Poke(0x20 + i, instrument.iModChar);
                    adlib.Poke(0x40 + i, instrument.iModScale);
                    adlib.Poke(0x60 + i, instrument.iModAttack);
                    adlib.Poke(0x80 + i, instrument.iModSustain);
                    adlib.Poke(0xE0 + i, instrument.iModWaveSel);
                    adlib.Poke(0xC0 + 7, instrument.iFeedback);
                    break;
                case 13: // tom
                    i = 18;
                    adlib.Poke(0x20 + i, instrument.iModChar);
                    adlib.Poke(0x40 + i, instrument.iModScale);
                    adlib.Poke(0x60 + i, instrument.iModAttack);
                    adlib.Poke(0x80 + i, instrument.iModSustain);
                    adlib.Poke(0xE0 + i, instrument.iModWaveSel);
                    adlib.Poke(0xC0 + 8, instrument.iFeedback);
                    break;
                case 14: // cymbal
                    i = 21;
                    adlib.Poke(0x20 + i, instrument.iModChar);
                    adlib.Poke(0x40 + i, instrument.iModScale);
                    adlib.Poke(0x60 + i, instrument.iModAttack);
                    adlib.Poke(0x80 + i, instrument.iModSustain);
                    adlib.Poke(0xE0 + i, instrument.iModWaveSel);
                    adlib.Poke(0xC0 + 8, instrument.iFeedback);
                    break;
                case 15: // hihat
                    i = 17;
                    adlib.Poke(0x20 + i, instrument.iModChar);
                    adlib.Poke(0x40 + i, instrument.iModScale);
                    adlib.Poke(0x60 + i, instrument.iModAttack);
                    adlib.Poke(0x80 + i, instrument.iModSustain);
                    adlib.Poke(0xE0 + i, instrument.iModWaveSel);
                    adlib.Poke(0xC0 + 7, instrument.iFeedback);
                    break;
            }
        }

        void SetChannelPitch(int channel, float note)
        {
            note -= 12;

            note = Math.Max(Math.Min(note, 84), 0);

            int octave = (int)(note / 12);
            note -= octave * 12;
            var freq = 343 * Math.Pow(2, note / 12f);            int fnum = (int)Math.Round(freq);

            if(octave < 0 || octave > 7)
                throw new Exception("bad octave");

            adlib.Poke(0xA0 + channel, fnum);
            channels[channel].regb &= ~0x1F;
            channels[channel].regb |= (octave << 2) | (fnum >> 8);
            adlib.Poke(0xB0 + channel, channels[channel].regb);
        }


        void SetChannelVelocity(int channel, float velocity)
        {
            //var optbl = new int[] { 0, 1, 2, 8, 9, 10, 16, 17, 18 };
            //adlib.Poke(0x43 + optbl[channel], (int)((1 - velocity) * 63.99));
        }

        void SetRhythmVelocity(int cmfChannel, float velocity)
        {
            /*switch(cmfChannel)
            {
                case 11: // bassdrum
                    adlib.Poke(0x40 + 19, regbd);
                    break;
                case 12: // snare
                    adlib.Poke(0x40 + 20, regbd);
                    break;
                case 13: // tom
                    adlib.Poke(0x40 + 18, regbd);
                    break;
                case 14: // cymbal
                    adlib.Poke(0x40 + 21, regbd);
                    break;
                case 15: // hihat
                    adlib.Poke(0x40 + 17, regbd);
                    break;
            }*/
        }
    }

    class Playback
    {
        public bool IsPlaying { get; private set; }
        private Thread thread;
        private Cmf cmf;
        private WasapiAudioRenderClient destination = new WasapiAudioRenderClient();
        private PlayerCore pc;

        public double SecTotal { get; private set; } = 0;
        public double SecPosition
        {
            get
            {
                return pc.Time; // destination.CurrentTime;
            }
        }

        public PlayerCore.ChannelActivity_T ChannelActivity
        {
            get
            {
                return pc.ChannelActivity;
            }
            set
            {
                pc.ChannelActivity = value;
            }
        }


        public Playback(Cmf cmf)
        {
            this.cmf = cmf;
            init();
        }

        private void init()
        {
            // read the midi data to determine the duration of the whole song:
            int totalTicks = 0;
            var mr = new MidiReader(new MemoryStream(cmf.mididata));
            while(!mr.End)
                totalTicks += mr.ReadEvent().delta;

            SecTotal = (double)totalTicks / cmf.ticksPerSecond;

            destination.Open(destination.Info.defaultPeriod, 2, 44100, FormatType.Int16);

            pc = new PlayerCore(destination.SampleRate, cmf);

            thread = new Thread(AudioThread);
            thread.Start();
        }

        public void Close()
        {
            requestStopThread = true;
            destination.WaitEvent.Set();
            thread.Join();
            destination = null;
        }

        public void Play()
        {
            if(!IsPlaying)
            {
                destination.Start();
                IsPlaying = true;
            }
        }

        public void Pause()
        {
            if(IsPlaying)
            {
                destination.Stop();
                IsPlaying = false;
            }
        }

        volatile bool requestStopThread = false;

        void AudioThread()
        {
            while(!pc.End && !requestStopThread)
            {
                destination.WaitEvent.WaitOne();
                var avail = destination.AvailableBytes;
                byte[] buffer = new byte[avail];
                pc.Process(buffer, avail);
                destination.Write(buffer, 0, avail);
            }
        }
    }
}
