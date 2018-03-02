/* srtuss's CMF player */

using System;

namespace CmfPlayer
{
    public class Adlib0
    {
        // the actual synthesis:
        enum CellState
        {
            Attack,
            Decay,
            Release,
            Constant,
            Disabled
        }

        const float ADJUSTSPEED = 0.75f;
        const float MODFACTOR = 4;

        Channel[] channels = new Channel[9];

        public Adlib0(int sampleRate, int numChannels)
        {
            this.sampleRate = sampleRate;
            bytesPerSample = numChannels == 2 ? 4 : 2;

            for(int i = 0; i < channels.GetLength(0); ++i)
            {
                channels[i] = new Channel();
                channels[i] = new Channel();
            }

            roptbl = new int[22];
            for(int i = 0; i < optbl.Length; ++i)
            {
                roptbl[optbl[i]] = i;
                roptbl[optbl[i] + 3] = i;
            }

            wavetables = new float[4, 2048];
            int n = wavetables.GetLength(1);
            int n2 = n / 2;
            for(int j = 0; j < n; ++j)
                wavetables[0, j] = (float)Math.Sin(2 * Math.PI * j / n);
            for(int j = 0; j < n2; ++j)
                wavetables[1, j] = wavetables[0, j];
            for(int j = 0; j < n; ++j)
                wavetables[2, j] = Math.Abs(wavetables[0, j]);
            for(int j = 0; j * 4 < n; ++j)
                wavetables[3, j] = wavetables[2, j];
            for(int j = 0; j * 4 < n; ++j)
                wavetables[3, j + n2] = wavetables[2, j];

            int a = 0;
        }

        class Channel
        {
            public Cell[] cells = new Cell[2];
            public bool additive = false;

            public float Clock()
            {
                float mix = 0;
                if(additive)
                {
                    // adlibemu.c suggests it works this way:
                    cells[1].state = cells[0].state;

                    cells[0].Clock(cells[0].val * cells[0].mfb);
                    cells[1].Clock(0);

                    mix += cells[0].val;
                    mix += cells[1].val;
                }
                else
                {
                    cells[0].Clock(cells[0].val * cells[0].mfb);
                    cells[1].Clock(cells[0].val * MODFACTOR);

                    mix += cells[1].val;
                }
                return mix;
            }
            public float ClockBassdrum()
            {
                float mix = 0;
                if(additive)
                {
                    cells[1].Clock(0);
                    mix += cells[1].val;
                }
                else
                {
                    cells[0].Clock(cells[0].val * cells[0].mfb);
                    cells[1].Clock(cells[0].val * MODFACTOR);

                    mix += cells[1].val;
                }
                return mix;
            }
        }

        struct Cell
        {
            public float t;
            public float tinc;
            public float val, amp, vol;
            public float a0, a1, a2, a3;
            public float sustainVal, decayMul, releaseMul;
            public int shape;
            public float mfb; // modulator feedback amount
            public bool holdSustain;
            public CellState state;
            public void Clock(float modulator)
            {
                switch(state)
                {
                    case CellState.Attack:
                        amp = ((a3 * amp + a2) * amp + a1) * amp + a0;
                        if(amp > 1)
                        {
                            amp = 1;
                            state = CellState.Decay;
                        }
                        break;
                    case CellState.Decay:
                        if(amp <= sustainVal)
                        {
                            if(holdSustain)
                            {
                                amp = sustainVal;
                                state = CellState.Constant;
                            }
                            else
                            {
                                state = CellState.Release;
                            }
                        }
                        else
                            amp *= decayMul;
                        break;
                    case CellState.Release:
                        if(amp <= 0.00001)
                        {
                            amp = 0;
                            state = CellState.Disabled;
                        }
                        amp *= releaseMul;
                        break;
                    case CellState.Disabled:
                        return;
                }

                float i = t + modulator;
                t += tinc;
                /*float wavev = (float)Math.Sin(i * 2 * Math.PI);
                switch(shape)
                {
                    case 1:
                        if(i >= .5f)
                            wavev = 0;
                        break;
                    case 2:
                        if(i >= .5f)
                            wavev *= -1f;
                        break;
                    case 3:
                        if(i >= .5f)
                            wavev *= i > .75f ? 0 : -1;
                        else
                            wavev *= i > .25f ? 0 : 1;
                        break;
                }*/
                float wavev = wavetables[shape, (int)(i * 2048) & 2047];
                val += (amp * vol * wavev - val) * ADJUSTSPEED;
                while(t >= 1f)
                    t -= 1f;
            }
        }

        float sampleRate;
        static float[,] wavetables;
        int bytesPerSample;
        bool rhythmEnable;
        Random rnd = new Random();
        public void GetSamples(byte[] buffer, int offset, int num)
        {
            int k = 0; // TD: why reset it here?

            // synthesize samples:
            for(int pos = 0; pos < num; pos += bytesPerSample)
            {
                float mix = 0;
                for(int i = 0; i < channels.Length; ++i)
                {
                    if(rhythmEnable && i >= 6) // 6-channel mode
                    {
                        if(i == 6)
                            mix += channels[i].ClockBassdrum();
                    }
                    else
                        mix += channels[i].Clock();
                }

                if(rhythmEnable)
                {
                    if(channels[7].cells[0].state != CellState.Disabled ||
                        channels[7].cells[1].state != CellState.Disabled ||
                        channels[8].cells[0].state != CellState.Disabled ||
                        channels[8].cells[1].state != CellState.Disabled)
                    {
                        // a linear congruential generator
                        k = k * 1664525 + 1013904223;

                        /*channels[7].cells[1].Clock((k & 1023) / 2048f); // snare
                        channels[7].cells[0].Clock((k & 2047) / 2048f); // hihat
                        channels[8].cells[1].Clock((k & 255) / 2048f); // cymbal*/
                        channels[7].cells[1].Clock((float)(rnd.NextDouble() * .5)); // snare
                        channels[7].cells[0].Clock((float)rnd.NextDouble()); // hihat
                        channels[8].cells[1].Clock((float)(rnd.NextDouble() * .25)); // cymbal
                        channels[8].cells[0].Clock(0); // tom

                        mix += channels[7].cells[1].val;
                        mix += channels[7].cells[0].val;
                        mix += channels[8].cells[1].val;
                        mix += channels[8].cells[0].val;
                    }
                }

                mix *= .25f;

                int vi = (short)(Math.Min(Math.Max(mix, -1), 1) * 32767.99);
                buffer[offset + pos] = (byte)vi;
                buffer[offset + pos + 1] = (byte)(vi >> 8);
                if(bytesPerSample == 4)
                {
                    buffer[offset + pos + 2] = (byte)vi;
                    buffer[offset + pos + 3] = (byte)(vi >> 8);
                }
            }
        }

        // simulation of the chip-control:

        float[] attackconst = { 1 / 2.82624f, 1 / 2.25280f, 1 / 1.88416f, 1 / 1.59744f };
        float[] decrelconst = { 1 / 39.28064f, 1 / 31.41608f, 1 / 26.17344f, 1 / 22.44608f };
        float[] kslmul = { 0f, .5f, .25f, 1f };
        float[] frqmul = { .5f, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 12, 12, 15, 15 };
        const float FRQSCALE = 49716f / 512;
        const float MFBFACTOR = 1f;
        int[,] ksl = new int[,]{{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 4, 5, 6, 7, 8},
                                {0, 0, 0, 0, 0, 3, 5, 7, 8, 10, 11, 12, 13, 14, 15, 16},
                                {0, 0, 0, 5, 8, 11, 13, 15, 16, 18, 19, 20, 21, 22, 23, 24},
                                {0, 0, 8, 13, 16, 19, 21, 23, 24, 26, 27, 28, 29, 30, 31, 32},
                                {0, 8, 16, 21, 24, 27, 29, 31, 32, 34, 35, 36, 37, 38, 39, 40},
                                {0, 16, 24, 29, 32, 35, 37, 39, 40, 42, 43, 44, 45, 46, 47, 48},
                                {0, 24, 32, 37, 40, 43, 45, 47, 48, 50, 51, 52, 53, 54, 55, 56}};

        int[] optbl = new int[] { 0, 1, 2, 8, 9, 10, 16, 17, 18 };
        int[] roptbl;
        int[] cartbl = new int[] { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1 };
        byte[] regs = new byte[256];
        int odrumstat = 0;

        public void Poke(int i, int v)
        {
            int lastv = regs[i];
            regs[i] = (byte)v;

            if((uint)(i - 0xA0) < 9) // channel freqLO register
            {
                int channel = i - 0xA0;
                int imodreg = optbl[channel];
                CellFreq(ref channels[channel].cells[0], channel, imodreg);
                CellFreq(ref channels[channel].cells[1], channel, imodreg + 3);
            }
            else if((uint)(i - 0xB0) < 9) // channel freqHI|octave|gate register
            {
                int channel = i - 0xB0;
                int imodreg = optbl[channel];
                if((v & 32) > (lastv & 32)) // gate bit was switched ON
                {
                    CellOn(ref channels[channel].cells[0], channel, imodreg, false);
                    CellOn(ref channels[channel].cells[1], channel, imodreg + 3, true);
                }
                else if((v & 32) < (lastv & 32)) // gate bit was switched OFF
                {
                    channels[channel].cells[0].state = CellState.Release;
                    channels[channel].cells[1].state = CellState.Release;
                }
                CellFreq(ref channels[channel].cells[0], channel, imodreg);
                CellFreq(ref channels[channel].cells[1], channel, imodreg + 3);
            }
            else if((uint)(i - 0xC0) < 9) // channel feedback|algo register
            {
                int channel = i - 0xC0;
                channels[channel].additive = (v & 1) > 0;
            }
            else if(i == 0xBD) // depth|rhythm register
            {
                rhythmEnable = (v & 32) > 0;

                if((v & 16) > (odrumstat & 16)) // bassdrum
                {
                    CellOn(ref channels[6].cells[0], 6, 16, false);
                    CellOn(ref channels[6].cells[1], 6, 19, true);
                    channels[6].cells[1].vol *= 2;
                }
                if((v & 8) > (odrumstat & 8)) // snare
                {
                    CellOn(ref channels[7].cells[1], 6, 20, false);
                    channels[7].cells[1].tinc *= 2 * (frqmul[regs[17 + 0x20] & 15] / frqmul[regs[20 + 0x20] & 15]);
                    if(((regs[20 + 0xe0] & 7) >= 3) && ((regs[20 + 0xe0] & 7) <= 5))
                        channels[7].cells[1].vol = 0;
                    channels[7].cells[1].vol *= 2;
                }
                if((v & 4) > (odrumstat & 4)) // tom
                {
                    // TD: implement
                }
                if((v & 2) > (odrumstat & 2)) // cymbal
                {
                    // TD: implement
                }
                if((v & 1) > (odrumstat & 1)) // hihat
                {
                    CellOn(ref channels[7].cells[0], 7, 17, false);
                    if(((regs[17 + 0xe0] & 7) == 1) || ((regs[17 + 0xe0] & 7) == 4) || ((regs[17 + 0xe0] & 7) == 5) || ((regs[17 + 0xe0] & 7) == 7))
                        channels[7].cells[0].vol = 0;
                    if((regs[17 + 0xe0] & 7) == 6)
                    {
                        // wouldn't this create a DC output form the table?
                        //channels[7].cells[0].wavemask = 0;
                        //channels[7].cells[0].waveform = &wavtable[(WAVPREC * 7) >> 2];
                    }
                }

                odrumstat = v;
            }
        }

        // set cell constants according to the content of the controlregisters:
        // i - channel register index
        // j - cell register index
        void CellOn(ref Cell c, int i, int j, bool iscarrier)
        {
            int frn = (((regs[i + 0xb0]) & 3) << 8) + regs[i + 0xa0];
            int oct = (((regs[i + 0xb0]) >> 2) & 7);
            int toff = (oct << 1) + ((frn >> 9) & ((frn >> 8) | (((regs[8] >> 6) & 1) ^ 1)));
            if((regs[j + 0x20] & 16) == 0)
                toff >>= 2;

            float f;
            float recipsamp = 1f / sampleRate;
            f = (float)Math.Pow(2, (regs[j + 0x60] >> 4) + (toff >> 2) - 1) * attackconst[toff & 3] * recipsamp;
            c.a0 = .0377f * f; c.a1 = 10.73f * f + 1; c.a2 = -17.57f * f; c.a3 = 7.42f * f;
            f = -7.4493f * decrelconst[toff & 3] * recipsamp;
            c.decayMul = (float)Math.Pow(2, f * Math.Pow(2, (regs[j + 0x60] & 15) + (toff >> 2)));
            c.releaseMul = (float)Math.Pow(2, f * Math.Pow(2, (regs[j + 0x80] & 15) + (toff >> 2)));
            //c.wavemask = wavemask[regs[j + 0xe0] & 7];
            //c.waveform = &wavtable[waveform[regs[j + 0xe0] & 7]];
            //if((regs[1] & 0x20) == 0) c.waveform = &wavtable[WAVPREC];
            //c.t = wavestart[regs[j + 0xe0] & 7];
            c.t = 0;

            c.holdSustain = (regs[j + 0x20] & 32) > 0;
            c.state = CellState.Attack; //c.cellfunc = docell0;

            c.tinc = (frn << oct) * frqmul[regs[j + 0x20] & 15] * recipsamp * FRQSCALE / 2048;
            c.vol = (float)Math.Pow(2, ((regs[j + 0x40] & 63) + kslmul[regs[j + 0x40] >> 6] * ksl[oct, frn >> 6]) * -.125f - 14f);
            c.sustainVal = (float)Math.Pow(2, (float)(regs[j + 0x80] >> 4) * -.5);
            if(!iscarrier)
                c.amp = 0;
            c.mfb = (float)Math.Pow(2, ((regs[i + 0xc0] >> 1) & 7) + 5) * MFBFACTOR;
            if((regs[i + 0xc0] & 14) == 0)
                c.mfb = 0;
            c.val = 0;

            c.shape = regs[j + 0xE0] & 3;

            c.vol *= (float)Math.Pow(2, 14);
            c.mfb /= 1 << 11;
            
            
        }

        // set frequency constants according to the content of the controlregisters:
        // i - channel register index
        // j - cell register index
        void CellFreq(ref Cell c, int i, int j)
        {
            int frn = (((regs[i + 0xb0]) & 3) << 8) + regs[i + 0xa0];
            int oct = (((regs[i + 0xb0]) >> 2) & 7);

            float recipsamp = 1f / sampleRate;
            c.tinc = (frn << oct) * frqmul[regs[j + 0x20] & 15] * recipsamp * FRQSCALE / 2048;
            c.vol = (float)Math.Pow(2, ((regs[j + 0x40] & 63) + kslmul[regs[j + 0x40] >> 6] * ksl[oct, frn >> 6]) * -.125f - 14f);

            c.vol *= (float)Math.Pow(2, 14);
        }
    }
}
