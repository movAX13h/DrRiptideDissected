using System;
using System.Drawing;
using System.Windows.Forms;

namespace riptide.Controls
{
    public class Light : Control
    {
        public Light()
        {
            Paint += Light_Paint;
            DoubleBuffered = true;
        }

        public float val = 0;

        public void Reset()
        {
            val = 0;
            Invalidate();
        }

        public void Tick(object sender, EventArgs e)
        {
            if (val > .02f)
            {
                Invalidate();
                val *= .8f;
            }
        }

        private void Light_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            float s = Width / 4;
            e.Graphics.FillEllipse(new SolidBrush(Color.Gray), Width / 2 - s, Height / 2 - s, s * 2, s * 2);
            s = val * Width / 2;
            e.Graphics.FillEllipse(new SolidBrush(Color.Honeydew), Width / 2 - s, Height / 2 - s, s * 2, s * 2);
        }
    }

}