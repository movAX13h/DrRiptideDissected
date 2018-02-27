using Gif.Components;
using System.Drawing;

namespace riptide.Riptide
{
    public class Sprite
    {
        public bool Ready { get; private set; } = false;
        public Bitmap[] Frames;
        public int NumFrames;

        public string Error { get; private set; } = "";

        public DatFileEntry Entry { get; private set; }

        public Sprite(DatFileEntry entry, Color[] palette)
        {
            Entry = entry;
            
            int i = 0;
            NumFrames = entry.Data[i++];
            Frames = new Bitmap[NumFrames];

            for (int frame = 0; frame < NumFrames; frame++)
            {
                int width = entry.Data[i++];
                int height = entry.Data[i++];

                Frames[frame] = new Bitmap(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color color = palette[entry.Data[i++]];
                        Frames[frame].SetPixel(x, y, color);
                    }
                }
            }

            Ready = true;
        }

        public Bitmap MakeIcon(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics gfx = Graphics.FromImage(bmp);

            Bitmap src = Frames[0];

            int w = src.Width;
            int h = src.Height;

            if (w > width)
            {
                w = width;
                h = w * src.Height / src.Width;
            }
            
            if (h > height)
            {
                h = height;
                w = h * src.Height / src.Width;
            }

            int x = (width - w) / 2;
            int y = (height - h) / 2;

            gfx.DrawImage(src, new Rectangle(x, y, w, h), new Rectangle(0, 0, src.Width, src.Height), GraphicsUnit.Pixel);
            gfx.Dispose();
            return bmp;
        }

        public bool SaveAsGif(string path)
        {
            Error = "";
            AnimatedGifEncoder encoder = new AnimatedGifEncoder();
            if (!encoder.Start(path))
            {
                Error = "Failed to start the GIF encoder :(";
                return false;
            }

            encoder.SetTransparent(Color.Black);
            encoder.SetDelay(100);
            encoder.SetRepeat(0); // -1:no repeat, 0:always repeat

            foreach (Bitmap bmp in Frames)
            {
                if (!encoder.AddFrame(bmp))
                {
                    Error = "Failed to add frame to GIF encoder :(";
                    return false;
                }
            }

            if (!encoder.Finish())
            {
                Error = "GIF encoder failed to finish :(";
                return false;
            }

            return true;
        }
    }
}
