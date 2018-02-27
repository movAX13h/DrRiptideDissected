using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace riptide.Riptide
{
    public class DatFileEntry
    {
        public enum DataType { Sprite, Image, Map, Text, SpeakerSound, SoundFX, Music, Unknown }

        public int ID = 0;
        public int Size;
        public int Modified;
        public string Filename;
        public int Offset;
        public byte[] Data;

        private Sprite cachedSprite;
        private PcxFile cachedPicture;
        private Map cachedMap;

        public DataType Type
        {
            get
            {
                string ext = Path.GetExtension(Filename);
                switch (ext.ToLower())
                {
                    case ".l":
                        return DataType.Sprite;
                    case ".m":
                        return DataType.Map;
                    case ".pcx":
                        return DataType.Image;
                    case ".txt":
                        return DataType.Text;

                    case ".pcs":
                        return DataType.SpeakerSound;
                    case ".voc":
                        return DataType.SoundFX;
                    case ".cmf":
                        return DataType.Music;

                    default:
                        return DataType.Unknown;
                }
            }
        }

        public string TypeString
        {
            get
            {
                return Regex.Replace(Type.ToString(), "(\\B[A-Z])", " $1");
            }
        }

        public bool Write(string targetDir)
        {
            if (Data == null || Data.Length == 0) return false;
            File.WriteAllBytes(Path.Combine(targetDir, Filename), Data);
            return true;
        }

        public Sprite GetSprite(Color[] palette, bool forceNew = false)
        {
            //if (cachedSprite != null && !forceNew) return cachedSprite;

            if (Data == null || Data.Length == 0) return null;
            if (Type != DataType.Sprite) return null;
            if (palette.Length != 256) return null;

            cachedSprite = new Sprite(this, palette);
            if (!cachedSprite.Ready) cachedSprite = null;
            
            return cachedSprite;
        }

        public PcxFile GetPicture()
        {
            if (Type != DataType.Image) return null;
            if (cachedPicture != null) return cachedPicture;

            cachedPicture = new PcxFile();
            if (cachedPicture.Load(Data)) return cachedPicture;
            throw new System.Exception("unknown error");
        }

        public Map GetMap()
        {
            if (Type != DataType.Map) return null;
            if (Data == null || Data.Length == 0) return null;
            if (cachedMap != null) return cachedMap;

            cachedMap = new Map(this);
            if (!cachedMap.Ready) cachedMap = null;

            return cachedMap;
        }

        public string GetText()
        {
            if (Type != DataType.Text) return "";
            if (Data == null || Data.Length == 0) return null;

            return System.Text.Encoding.Default.GetString(Data);
        }

        public override string ToString()
        {
            return Filename + " @ " + Offset.ToString();
        }
    }
}
