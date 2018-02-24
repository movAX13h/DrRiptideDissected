using System;
using System.Drawing;

namespace riptide.Riptide
{
    public class Game
    {
        public static string ArchiveFile = "riptide.dat"; // hardcoded in exe
        public static string PcxContainingMainPalette = "P_FRAME.PCX"; // hardcoded in exe, loaded first

        public static string SpriteNameById(int id) // hardcoded in exe
        {
            return "";
        }

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
                Error = $"Unable to find '{PcxContainingMainPalette}' which contains the main game color palette";
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
