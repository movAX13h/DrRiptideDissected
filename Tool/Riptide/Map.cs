using System;
using System.Collections.Generic;
using System.Drawing;

namespace riptide.Riptide
{
    public class Map
    {
        public DatFileEntry Entry { get; private set; }

        public bool Ready { get; private set; } = false;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public MapCell[] Cells { get; private set; }
        public MapTile[] Tiles { get; private set; }
        public Color[] Palette { get; private set; }
        public int[] Positions { get; private set; }

        public int PlayerSpawn = 0;

        #region strings hardcoded in exe
        public static string PositionEntryTypeByNumber(int nr, int value)
        {
            switch(nr)
            {
                case 0: return "player spawn";
                case 1: return "level exit";
                case 2: return "message: \"You need a key for this door.\""; // this message is different from the others below; text is constant, the value is the position
                case 3: return "key gate";
                case 4: return "level exit left";

                case 5:
                case 6:
                case 7:
                case 8:
                case 9: return "unknown";

                case 10: return "teleport 1 IN";
                case 11: return "teleport 1 OUT";
                case 12: return "teleport 2 IN";
                case 13: return "teleport 2 OUT";
                case 14: return "teleport 3 IN";
                case 15: return "teleport 3 OUT";
                case 16: return "teleport 4 IN";
                case 17: return "teleport 4 OUT";
                case 18: return "teleport 5 IN";
                case 19: return "teleport 5 OUT";
                case 20: return "teleport 6 IN";
                case 21: return "teleport 6 OUT";
                case 22: return "teleport 7 IN";
                case 23: return "teleport 7 OUT";
                case 24: return "teleport 8 IN";
                case 25: return "teleport 8 OUT";
                case 26: return "teleport 9 IN";
                case 27: return "teleport 9 OUT";
                case 28: return "teleport 10 IN";
                case 29: return "teleport 10 OUT";

                case 30: return "message 1 position";
                case 31: return "message 1: \"" + MessageByID(value) + "\"";
                case 32: return "message 2 position";
                case 33: return "message 2: \"" + MessageByID(value) + "\"";
                case 34: return "message 3 position";
                case 35: return "message 3: \"" + MessageByID(value) + "\"";
                case 36: return "message 4 position";
                case 37: return "message 4: \"" + MessageByID(value) + "\"";

                default: return "unknown";
            }
        }

        public static string MessageByID(int id)
        {
            switch(id)
            {
                case 0: return "You need a key for this door.";
                case 1: return "You got the key!";
                case 2: return "Think!";
                case 3: return "Extra fire power added!";
                case 4: return "Auto-fire added!";
                case 5: return "WARNING: Air is low.";
                case 6: return "Watch out for those piranas!";
                case 7: return "Auto Pilot ON.";
                case 8: return "WARNING: JASON power low.";
                case 9: return "WARNING: Shield is low.";
                case 10: return "SHOOT THE BARRELS infobox";
                case 12: return "PULSE CANNON infobox";
                case 13: return "CAVES infobox";
                case 14: return "JASON SUB infobox";

                case 11: 
                default: return "invalid";
            }
        }

        public struct MapInfo
        {
            public string Title;
            public string Password;
            public string Music;

        }

        public static MapInfo InfoByFilename(string filename)
        {
            switch (filename.ToLower())
            {
                case "1-1.m": return new MapInfo { Title = "Shallow Sea", Password = "1", Music = "1.cmf" };
                case "1-2.m": return new MapInfo { Title = "Micro Menace", Password = "UR2GD", Music = "2.cmf" };
                case "1-3.m": return new MapInfo { Title = "Tulip Tango", Password = "URGR8", Music = "3.cmf" };
                case "1-4.m": return new MapInfo { Title = "Red Tide", Password = "4GOOD", Music = "1.cmf" };
                case "1-5.m": return new MapInfo { Title = "Fathoms of Teeth", Password = "2MUCH4U", Music = "2.cmf" };
                case "1-6.m": return new MapInfo { Title = "Think Tank", Password = "ACE", Music = "3.cmf" };
                case "bs1.m": return new MapInfo { Title = "Oscar's Lair", Password = "BS1", Music = "5.cmf" };
                case "2-1.m": return new MapInfo { Title = "Atlantis", Password = "DNUNDR", Music = "oxygen.cmf" };
                case "2-2.m": return new MapInfo { Title = "Aqua Tremendom", Password = "OUT2GTU", Music = "4.cmf" };
                case "2-3.m": return new MapInfo { Title = "Spawning Waters", Password = "AIC", Music = "bossa.cmf" };
                case "2-4.m": return new MapInfo { Title = "JASON Quest", Password = "HANG10", Music = "1.cmf" };
                case "2-5.m": return new MapInfo { Title = "Frantic Attack", Password = "RUN4IT", Music = "weerd.cmf" };
                case "bs2.m": return new MapInfo { Title = "Enter Otis", Password = "BS2", Music = "chaos.cmf" };
                case "3-1.m": return new MapInfo { Title = "Sea Escape", Password = "GETIT", Music = "1.cmf" };
                case "3-2.m": return new MapInfo { Title = "Deep Enigma", Password = "URINDE", Music = "oxygen.cmf" };
                case "3-3.m": return new MapInfo { Title = "Sink or Swim", Password = "SOS", Music = "4.cmf" };
                case "3-4.m": return new MapInfo { Title = "Marathon", Password = "RUN2ME", Music = "3.cmf" };
                case "3-5.m": return new MapInfo { Title = "Lab Rynth", Password = "512TR", Music = "chaos.cmf" };
                case "3-6.m": return new MapInfo { Title = "Abyss of Peril", Password = "2B4UDY", Music = "turn.cmf" };
                case "3-7.m": return new MapInfo { Title = "Halls of Hell", Password = "HOH", Music = "2.cmf" };
                case "3-8.m": return new MapInfo { Title = "Mysterious Maze", Password = "RIP", Music = "oxygen.cmf" };
                case "bs3.m": return new MapInfo { Title = "Confrontation", Password = "BS3", Music = "5.cmf" };
                case "sec1.m": return new MapInfo { Title = "Outpost Enigma", Password = "SEC1", Music = "4.cmf" };
                case "sec2.m": return new MapInfo { Title = "??????", Password = "SEC2", Music = "weerd.cmf" };
            }

            return new MapInfo { Title = "unknown", Password = "", Music = "" };
        }
        #endregion

        public Map(DatFileEntry entry)
        {
            Entry = entry;

            int i = 0;

            Width = entry.Data[i];
            i += 2;
            Height = entry.Data[i];
            i += 2;

            loadPalette();

            // load cells
            int numCells = Width * Height;
            Cells = new MapCell[numCells];

            for(int j = 0; j < numCells; j++)
            {
                MapCell cell = new MapCell();
                cell.TileID = entry.Data[i] + entry.Data[i + 1] * 256;
                cell.SolidEntityID = entry.Data[i + 2];
                cell.EntityID = entry.Data[i + 3];
                Cells[j] = cell;
                i += 4;
            }

            // load tiles
            Tiles = new MapTile[512];

            for(int j = 0; j < 512; j++)
            {
                MapTile tile = new MapTile();
                if (!tile.Load(entry.Data.SubArray(i, 64), Palette)) return;

                Tiles[j] = tile;
                i += 64;
            }

            loadPositions();

            Ready = true;
        }

        private void loadPositions()
        {
            Positions = new int[50];
            int num = 0;

            for (int i = Entry.Data.Length - 104; i < Entry.Data.Length - 4; i += 2)
            {
                int pos = Entry.Data[i] + Entry.Data[i + 1] * 256;
                if (pos != 0) Positions[num] = pos;
                num++;
            }
        }

        private void loadPalette()
        {
            Palette = new Color[256];
            int i = Entry.Data.Length - 872;

            for (int j = 0; j < 256; j++)
            {
                byte r = (byte)Math.Floor(Entry.Data[i    ] * 255f / 63f);
                byte g = (byte)Math.Floor(Entry.Data[i + 1] * 255f / 63f);
                byte b = (byte)Math.Floor(Entry.Data[i + 2] * 255f / 63f);

                Color col = Color.FromArgb(255, r, g, b);
                Palette[j] = col;

                i += 3;
            }
        }
    }
}
