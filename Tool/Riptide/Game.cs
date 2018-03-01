using System;
using System.Drawing;

namespace riptide.Riptide
{
    public class Game
    {
        #region hardcoded in exe
        public static string ArchiveFile = "riptide.dat"; // hardcoded in exe
        public static string PcxContainingMainPalette = "P_FRAME.PCX"; // hardcoded in exe, loaded first

        public static string EntitySpriteName(int id, bool evenPos) // hardcoded in exe
        {
            switch(id)
            {
                case 1: return "DOOR.L";
                case 2: return "DOOR.L";
                case 3: return "DOOR.L";
                case 4: return "COIN.L";
                
                case 8: return "MINE.L";
                case 12: return "ZAP_UD.L";
                case 16: return evenPos ? "POD1.L" : "POD2.L";
                case 20: return evenPos ? "FISH1R.L" : "FISH2R.L";
                case 24: return "WEED1.L";
                case 28: return "TULIPL.L";
                case 32: return "CHEST.L";
                case 36: return "PIRANAL.L";
                case 40: return "GEM.L";
                case 44: return evenPos ? "DUCT_R.L" : "DUCT_L.L";
                case 48: return "DUCT_D.L";
                case 52: return "BLOCK.L";
                case 56: return "FACE_R.L";
                case 60: return "SERP_R.L";
                case 64: return "CRAB.L";
                case 68: return "PIECE_1.L";
                case 72: return "JELLY.L";
                case 76: return "SHARKL.L";
                case 80: return "BONUS1.L";
                case 84: return "TENT_IN.L";
                case 88: return "SPIKES_U.L";
                case 92: return "STATUE.L";
                case 96: return "FIRE_PIT.L";
                case 100: return "SHUTL_L.L";
                case 104: return "CLAM.L";
                case 108: return "CANNONL.L";
                case 112: return "FACE_L.L";
                case 116: return "SHIPL.L";
                
            }

            return "";
        }

        public static string EntityInfo(int id, bool evenPos) // functionaliy is part of the game and hardcoded in exe
        {
            switch (id)
            {
                case 1: return "door 1";
                case 2: return "door 2";
                case 3: return "door 3";
                case 28: return "spitting tulip";
                case 32: return "chest spawning many coins";
                case 44: return "pushing player subs " + (evenPos ? "right" : "left");
                case 48: return "pushing player subs " + (evenPos ? "up" : "down");
                case 68: return "piece of pulse cannon";
                case 84: return "tentacle in hole";
                case 100: return "shooting rockets";
                case 104: return "spawning a gem";
                case 108: return "always looking to player side";
                case 116: return "dropping bombs (SHPBMB.L)";
            }

            return "";
        }

        public static string ShootableSpriteName(int id, bool evenPos) // hardcoded in exe
        {
            switch (id)
            {
                case 1: return "BARREL2.L";
                case 2: return "BARREL2.L";
                case 3: return "BARREL2.L";
                case 4: return "BARREL2.L";
                case 5: return "BARREL2.L";
                case 6: return "BARREL2.L";
                case 7: return "BARREL2.L";
                case 8: return "BARREL2.L";
                case 9: return "BARREL2.L";
                case 16: return evenPos ? "BARREL3.L" : "BARREL1.L";
                case 32: return "BARREL1.L";
                case 64: return "SWITCH.L";
                case 128: return "SWITCH.L";
                case 192: return "SWITCH.L";
            }

            return "";
        }

        public static string ShootableInfo(int id, bool evenPos) // functionaliy is part of the game and hardcoded in exe
        {
            switch (id)
            {
                case 1: return "spawning extra air";
                case 2: return "spawning extra shield";
                case 3: return "spawning extra fire power item";
                case 4: return "spawning PU_TOP item (unknown effect)";
                case 5: return "spawning extra 1-up item";
                case 6: return "spawning green key";
                case 7: return "spawning auto-fire";
                case 8: return "spawning Jason sub";
                case 9: return "spawning Jason sub";
                case 16: return "spawning a coin";
                case 32: return "spawning " + (evenPos ? "POD1.L" : "POD2.L");
                case 64: return "opens door 1";
                case 128: return "opens door 2";
                case 192: return "opens door 3";
            }

            return "";
        }

        public static string TriggerEntryTypeByNumber(int nr, int value)
        {
            // positions/triggers/messages hardcoded in exe
            switch (nr)
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
            // strings are hardcoded in exe
            switch (id)
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
            // strings are hardcoded in exe
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

        public bool Ready = false;
        public string Error { get; private set; } = "";
        public DatFile Archive { get; private set; }
        public Color[] MainPalette { get; private set; }

        public Game()
        {
            
        }

        public bool Load()
        {
            if (Ready) return true;

            Archive = new DatFile(ArchiveFile);

            // unpack archive
            if (!Archive.Unpack())
            {
                Error = "Processing archive failed: " + Archive.Error;
                return false;
            }

            // load frame pcx which contains the main game palette
            DatFileEntry framePcx = Archive.GetByName(PcxContainingMainPalette);
            if (framePcx == null)
            {
                Error = $"Unable to find '{PcxContainingMainPalette}'";
                return false;
            }
            
            try
            {
                PcxFile pcx = framePcx.GetPicture();
                MainPalette = (Color[])pcx.Palette.Clone();
                MainPalette[0] = Color.Transparent;
            }
            catch(Exception e)
            {
                Error = $"Failed to decode PCX image '{PcxContainingMainPalette}': {e.Message}";
                return false;
            }

            Ready = true;
            return true;
        }
    }
}
