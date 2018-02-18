
using System.Drawing;

namespace riptide.Riptide
{
    public class MapTile
    {
        public Bitmap Bitmap;

        public MapTile()
        {
            Bitmap = new Bitmap(8, 8);
        }

        public bool Load(byte[] data, Color[] palette)
        {
            if (data.Length != 64) return false;

            for(int i = 0; i < data.Length; i++)
            {
                int x = i % 8;
                int y = i / 8;

                Bitmap.SetPixel(x, y, palette[data[i]]);
            }

            return true;
        }
    }
}
