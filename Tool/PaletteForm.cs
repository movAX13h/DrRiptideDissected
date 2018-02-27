using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using riptide.Riptide;

namespace riptide
{
    public partial class PaletteForm : Form
    {
        private Map map;
        private Font font;

        private long startTicks;
        private Timer timer;

        private Bitmap canvas;
        private SolidBrush brush;
        private int cellSize;

        private int frame = 0;

        public PaletteForm(Map map)
        {
            InitializeComponent();

            this.map = map;

            font = new Font(SystemFonts.DefaultFont.FontFamily, 8, FontStyle.Regular);

            /*
            rotationLabel.Text = "[ROTATION] START: " + map.PaletteRotation.Start.ToString() + 
                ", END: " + map.PaletteRotation.End.ToString() + 
                ", SPEED: " + map.PaletteRotation.Speed.ToString() + 
                ", UNKNOWN: " + map.PaletteRotation.Unknown.ToString();
            */

            infoLabel.Text = "unknown: " + map.PaletteRotation.Unknown;

            startTicks = DateTime.Now.Ticks;

            // setup timer for palette rotation
            if (map.PaletteRotation.Start > 0)
            {
                timer = new Timer();
                timer.Interval = 33 * (map.PaletteRotation.Speed + 1);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            //else timeLabel.Text = "";

            cellSize = 20;
            brush = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
            canvas = new Bitmap(160, 640);
            draw();
        }

        private void draw()
        {
            Graphics gfx = Graphics.FromImage(canvas);
            
            int i = 0;
            foreach (Color col in map.Palette)
            {
                int x = cellSize * (i % 8);
                int y = cellSize * (i / 8);

                brush.Color = col;
                gfx.FillRectangle(brush, x, y, cellSize, cellSize);

                if (indicesCheckBox.Checked) drawText(gfx, i.ToString(), x, y);
                i++;
            }

            canvasBox.Image = canvas;
            gfx.Dispose();
        }

        private void drawPaletteRotation(float time)
        {
            // frame at current time and palette rotation speed (skips actually)
            //int frame = (int)Math.Round(time / (0.0333333f * (map.PaletteRotation.Speed + 1f))) % map.PaletteRotation.Length;
            //timeLabel.Text = "Frame: " + frame.ToString();

            Graphics gfx = Graphics.FromImage(canvas);
            int i = 0;
            for (int cell = map.PaletteRotation.Start; cell < map.PaletteRotation.End; cell++)
            {
                int x = cellSize * (cell % 8);
                int y = cellSize * (cell / 8);
                int col = map.PaletteRotation.Start + (frame + i) % map.PaletteRotation.Length;
                brush.Color = map.Palette[col];
                gfx.FillRectangle(brush, x, y, cellSize, cellSize);
                if (indicesCheckBox.Checked) drawText(gfx, col.ToString(), x, y);
                i++;
            }

            canvasBox.Image = canvas;
            gfx.Dispose();

            frame++;
        }

        private void drawText(Graphics gfx, string text, int x, int y)
        {
            var textSize = gfx.MeasureString(text, font);
            gfx.DrawString(text, font, Brushes.Black, x + 10 - textSize.Width / 2, y + 4);
            gfx.DrawString(text, font, Brushes.White, x + 10 - textSize.Width / 2 - 1, y + 4 - 1);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            float time = (DateTime.Now.Ticks - startTicks) / 10000000f;
            //timeLabel.Text = time.ToString("0.000") + "s";
            drawPaletteRotation(time);
        }

        private void indicesCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            draw();
        }
    }
}
