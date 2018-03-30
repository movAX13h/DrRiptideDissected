using riptide.Riptide;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace riptide
{
    public partial class TilesForm : Form
    {
        private int currentZoom = 3;
        private Map map;

        public TilesForm(Map map)
        {
            this.map = map;
            InitializeComponent();

            draw();
        }

        private void draw(bool original = false)
        {
            int zoom = original ? 1 : currentZoom;

            Bitmap bmp = new Bitmap(40 * 8 * zoom, 13 * 8 * zoom);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            int i = 0;
            foreach(MapTile tile in map.Tiles)
            {
                int x = (i % 40) * 8 * zoom;
                int y = (int)Math.Floor((i / 40f)) * 8 * zoom;
                gfx.DrawImage(tile.Bitmap, new Rectangle(x, y, 8 * zoom, 8 * zoom), new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
                //gfx.DrawString(i.ToString(), SystemFonts.MenuFont, Brushes.White, x, y);
                i++;
            }

            if (!original)
            {
                Pen gridPen = new Pen(Color.FromArgb(50, 0, 0, 0));

                int w = 40 * 8 * zoom;
                int h = 13 * 8 * zoom;

                for (int x = 0; x <= 40; x++)
                {
                    int gx = x * 8 * zoom;
                    gfx.DrawLine(gridPen, gx, 0, gx, h);
                }

                for (int y = 0; y <= 13; y++)
                {
                    int gy = y * 8 * zoom;
                    gfx.DrawLine(gridPen, 0, gy, w, gy);
                }
            }

            //gfx.DrawRectangle(Pens.Black, new Rectangle(0, 0, bmp.Width, bmp.Height));
            canvasBox.Image = bmp;
            gfx.Dispose();
        }

        private void zoomDropDown_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            currentZoom = 10 - zoomDropDown.DropDownItems.IndexOf(e.ClickedItem);
            zoomDropDown.Text = e.ClickedItem.Text;
            draw();
        }

        private void pngButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "PNG Image (*.png)|.png";
                dialog.FileName = map.Entry.Filename + ".png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    draw(true);
                    canvasBox.Image.Save(dialog.FileName);
                    draw();
                }
            };
        }
    }
}
