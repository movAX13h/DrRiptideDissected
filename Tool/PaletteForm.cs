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

        private List<Color> loop;

        public PaletteForm(Map map)
        {
            InitializeComponent();

            this.map = map;

            font = new Font(SystemFonts.DefaultFont.FontFamily, 8, FontStyle.Regular);

            // the last 4 bytes of map data are palette rotation information
            int start = map.Entry.Data.Length - 4;
            rotationLabel.Text = "[ROTATION] START: " + map.Entry.Data[start].ToString() + 
                ", END: " + map.Entry.Data[start + 1].ToString() + 
                ", SPEED: " + map.Entry.Data[start + 2].ToString() + 
                ", UNKNOWN: " + map.Entry.Data[start + 3].ToString();

            startTicks = DateTime.Now.Ticks;

            // setup timer for palette rotation
            if (map.Entry.Data[start] > 0)
            {
                timer = new Timer();
                timer.Interval = 100;
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            else timeLabel.Text = "";

            cellSize = 20;
            brush = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
            canvas = new Bitmap(320, 320);
            draw();
        }

        private void draw()
        {
            Graphics gfx = Graphics.FromImage(canvas);
            
            int i = 0;
            foreach (Color col in map.Palette)
            {
                int x = cellSize * (i % 16);
                int y = cellSize * (i / 16);

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
            int offset = map.Entry.Data.Length - 4;

            int start = map.Entry.Data[offset];
            int end = map.Entry.Data[offset + 1];
            int length = end - start;
            int speed = map.Entry.Data[offset + 2];
            int frame = (int)Math.Floor(time / (0.0333333f * (speed + 1f))) % length;

            timeLabel.Text = "Frame: " + frame.ToString();

            Graphics gfx = Graphics.FromImage(canvas);
            int i = 0;
            for (int cell = start; cell < end; cell++)
            {
                int x = cellSize * (cell % 16);
                int y = cellSize * (cell / 16);
                int col = start + (frame + i) % length;
                brush.Color = map.Palette[col];
                gfx.FillRectangle(brush, x, y, cellSize, cellSize);
                if (indicesCheckBox.Checked) drawText(gfx, col.ToString(), x, y);
                i++;
            }

            canvasBox.Image = canvas;
            gfx.Dispose();
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
