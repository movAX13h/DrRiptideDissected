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

        private void draw()
        {
            Bitmap bmp = new Bitmap(40 * 8 * currentZoom, 13 * 8 * currentZoom);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            int i = 0;
            foreach(MapTile tile in map.Tiles)
            {
                int x = (i % 40) * 8 * currentZoom;
                int y = (int)Math.Floor((i / 40f)) * 8 * currentZoom;
                gfx.DrawImage(tile.Bitmap, new Rectangle(x, y, 8 * currentZoom, 8 * currentZoom), new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
                //gfx.DrawString(i.ToString(), SystemFonts.MenuFont, Brushes.White, x, y);
                i++;
            }

            Pen gridPen = new Pen(Color.FromArgb(50, 0, 0, 0));

            int w = 40 * 8 * currentZoom;
            int h = 13 * 8 * currentZoom;

            for (int x = 0; x <= 40; x++)
            {
                int gx = x * 8 * currentZoom;
                gfx.DrawLine(gridPen, gx, 0, gx, h);
            }

            for (int y = 0; y <= 13; y++)
            {
                int gy = y * 8 * currentZoom;
                gfx.DrawLine(gridPen, 0, gy, w, gy);
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
    }
}
