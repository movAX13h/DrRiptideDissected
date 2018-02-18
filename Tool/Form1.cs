using Gif.Components;
using riptide.Controls;
using riptide.Riptide;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace riptide
{
    public partial class Form1 : Form
    {
        private Game game;

        private Bitmap currentBitmap = null;
        private Sprite currentSprite = null;
        private Map currentMap = null;
        private int currentSpriteFrame = 0;
        private int currentZoom = 3;

        public Form1()
        {
            InitializeComponent();

            statusLabel.Text = "";
            statusDetailsLabel.Text = "";
            datFileList.ListViewItemSorter = new ListViewColumnSorter();
            game = new Game();
        }

        private void showFileDetails(DatFileEntry entry)
        {
            selectionLabel.Text = "";
            statusDetailsLabel.Text = "";
            currentBitmap = null;
            currentSprite = null;
            currentMap = null;
            canvasPanel.Visible = false;

            pngButton.Visible = false;

            frameSelectionPanel.Visible = false;
            currentSpriteFrame = 0;

            if (entry == null) return;

            selectionLabel.Text = "[" + entry.TypeString.ToUpper() + "] " + 
                Path.GetFileName(Game.ArchiveFile) + " / " + 
                entry.Filename;

            switch(entry.Type)
            {
                case DatFileEntry.DataType.Sprite:
                    currentSprite = entry.GetSprite(game.MainPalette);

                    if (currentSprite == null)
                    {
                        MessageBox.Show("Failed to load sprite");
                        return;
                    }

                    currentBitmap = currentSprite.Frames[0];

                    statusDetailsLabel.Text = $"Frame size: {currentBitmap.Width}x{currentBitmap.Height}";
                    
                    if (currentSprite.Frames.Length > 1)
                    {
                        frameSelectionPanel.Visible = true;
                        frameLabel.Text = "1/" + currentSprite.Frames.Length;
                        currentSpriteFrame = 0;
                    }

                    pngButton.Visible = true;
                    canvasPanel.Visible = true;
                    break;

                case DatFileEntry.DataType.Image:
                    try
                    {
                        PcxFile pcx = entry.GetPicture();
                        currentBitmap = pcx.Bitmap;
                        statusDetailsLabel.Text = $"Image size: {currentBitmap.Width}x{currentBitmap.Height}";
                        pngButton.Visible = true;
                        canvasPanel.Visible = true;
                    }
                    catch (Exception e)
                    { 
                        MessageBox.Show("Failed to convert from PCX to bitmap: " + e.Message, "Conversion failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case DatFileEntry.DataType.Map:
                    currentMap = entry.GetMap();
                    if (currentMap == null)
                    {
                        MessageBox.Show("Failed to load map");
                        return;
                    }

                    statusDetailsLabel.Text = $"Size: {currentMap.Width}x{currentMap.Height}";
                    canvasPanel.Visible = true;
                    break;
            }

            draw();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (game.Load())
            {
                datFileList.Items.Clear();

                foreach (DatFileEntry entry in game.Archive.Files)
                {
                    datFileList.Items.Add(new FileListItem(entry));
                }

                startButton.Enabled = false;
                statusLabel.Text = $"Loaded {game.Archive.Files.Count} items";
                statusDetailsLabel.Text = "Select an item to show details.";
                saveGifsButton.Enabled = game.Archive.Files.Count > 0;
            }
            else
            {
                MessageBox.Show("Failed: " + game.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Failed to load game data!";
            }
        }

        #region dat files list
        private void datFileList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewColumnSorter sorter = datFileList.ListViewItemSorter as ListViewColumnSorter;

            if (e.Column == sorter.SortColumn)
            {
                if (sorter.Order == SortOrder.Ascending)
                {
                    sorter.Order = SortOrder.Descending;
                }
                else
                {
                    sorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                sorter.SortColumn = e.Column;
                sorter.Order = SortOrder.Ascending;
            }

            datFileList.Sort();
        }

        private void datFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            showFileDetails(datFileList.SelectedItems.Count == 0 ? null : ((FileListItem)datFileList.SelectedItems[0]).Entry);
        }
        #endregion

        Bitmap canvas;

        private void draw()
        {
            if (canvas != null)
            {
                canvas.Dispose();
                canvas = null;
            }
            
            int x, y, w, h;
            Graphics gfx = null;

            if (currentBitmap != null)
            {
                x = 0;
                y = 0;
                w = currentBitmap.Width * currentZoom;
                h = currentBitmap.Height * currentZoom;

                canvas = new Bitmap(w, h);
                gfx = Graphics.FromImage(canvas);
                gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                gfx.DrawImage(currentBitmap,
                    new Rectangle(x, y, w, h),
                    new Rectangle(0, 0, currentBitmap.Width, currentBitmap.Height),
                    GraphicsUnit.Pixel);
            }
            else if (currentMap != null)
            {
                Pen gridPen = Pens.Gray;
                int cellSize = 16;

                w = currentMap.Width * cellSize;
                h = currentMap.Height * cellSize;

                canvas = new Bitmap(w + 1, h + 1);
                gfx = Graphics.FromImage(canvas);
                gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                for (x = 0; x < currentMap.Width; x++)
                {
                    int gx = x * cellSize + 1;
                    gfx.DrawLine(gridPen, gx, 0, gx, h);
                }

                for (y = 0; y < currentMap.Height; y++)
                {
                    int gy = y * cellSize + 1;
                    gfx.DrawLine(gridPen, 0, gy, w, gy);
                }
            }

            canvasBox.Image = canvas;
            if (gfx != null) gfx.Dispose();
        }

        /*
        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            int x, y, w, h;

            if (currentBitmap != null)
            {
                x = 1;
                y = 1;
                w = currentBitmap.Width * currentZoom;
                h = currentBitmap.Height * currentZoom;

                if (canvasPanel.Width > w) x = (int)Math.Ceiling((canvasPanel.Width - w) / 2f);
                if (canvasPanel.Height > h) y = (int)Math.Ceiling((canvasPanel.Height - h) / 2f);

                e.Graphics.DrawImage(currentBitmap, 
                    new Rectangle(x, y, w, h), 
                    new Rectangle(0, 0, currentBitmap.Width, currentBitmap.Height), 
                    GraphicsUnit.Pixel);
            }

            if (currentMap != null)
            {
                Pen gridPen = Pens.Gray;
                int cellSize = 2;

                int gw = currentMap.Width * cellSize;
                int gh = currentMap.Height * cellSize;

                for (x = 0; x < currentMap.Width; x++)
                {
                    int gx = x * cellSize;
                    e.Graphics.DrawLine(gridPen, gx, 0, gx, gh);
                }

                for (y = 0; y < currentMap.Height; y++)
                {
                    int gy = y * cellSize;
                    e.Graphics.DrawLine(gridPen, 0, gy, gw, gy);
                }
            }
        }
        */
        
        private void prevFrame()
        {
            if (currentSprite.Frames.Length == 1) return;

            currentSpriteFrame--;
            if (currentSpriteFrame < 0) currentSpriteFrame = currentSprite.Frames.Length - 1;

            currentBitmap = currentSprite.Frames[currentSpriteFrame];
            draw();

            frameLabel.Text = (currentSpriteFrame + 1) + "/" + currentSprite.Frames.Length;
            statusDetailsLabel.Text = $"Frame size: {currentBitmap.Width}x{currentBitmap.Height}";
        }
        
        private void nextFrame()
        {
            if (currentSprite.Frames.Length == 1) return;

            currentSpriteFrame++;
            if (currentSpriteFrame >= currentSprite.Frames.Length) currentSpriteFrame = 0;

            currentBitmap = currentSprite.Frames[currentSpriteFrame];
            draw();

            frameLabel.Text = (currentSpriteFrame + 1) + "/" + currentSprite.Frames.Length;
            statusDetailsLabel.Text = $"Frame size: {currentBitmap.Width}x{currentBitmap.Height}";
        }

        private void zoomDropDown_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            currentZoom = 10 - zoomDropDown.DropDownItems.IndexOf(e.ClickedItem);
            zoomDropDown.Text = e.ClickedItem.Text;
            draw();
        }

        private void prevFrameButton_Click(object sender, EventArgs e)
        {
            prevFrame();
        }

        private void nextFrameButton_Click(object sender, EventArgs e)
        {
            nextFrame();
        }

        private void datFileList_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentSprite == null) return;

            if (e.KeyCode == Keys.Left) prevFrame();
            if (e.KeyCode == Keys.Right) nextFrame();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if (canvasPanel.Visible) canvasPanel.Invalidate();
        }

        private void pngButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = ".png";
            dialog.Filter = "Portable Network Graphic (*.png)|*.png";
            dialog.FileName = Path.GetFileNameWithoutExtension(currentSprite.Entry.Filename);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentBitmap.Save(dialog.FileName);
            }
        }

        private void gifButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = ".gif";
            dialog.Filter = "Animated Graphics Interchange Format (*.gif)|*.gif";
            dialog.FileName = Path.GetFileNameWithoutExtension(currentSprite.Entry.Filename);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (!currentSprite.SaveAsGif(dialog.FileName))
                {
                    MessageBox.Show(currentSprite.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void saveGifsButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("exports")) Directory.CreateDirectory("exports");
            int num = 0;
            int failed = 0;

            foreach(DatFileEntry file in game.Archive.Files)
            {
                if (file.Type == DatFileEntry.DataType.Sprite)
                {
                    Sprite sprite = file.GetSprite(game.MainPalette);
                    if (!sprite.Ready)
                    {
                        MessageBox.Show($"Failed to get sprite for '{file.Filename}'!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        failed++;
                        continue;
                    }

                    if (!sprite.SaveAsGif("exports/" + Path.GetFileNameWithoutExtension(file.Filename) + ".gif"))
                    {
                        MessageBox.Show($"Failed to make GIF for '{file.Filename}': " + sprite.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        failed++;
                        continue;
                    }
                    else num++;
                }
            }

            MessageBox.Show($"{num} GIFs written.\n{failed} failed.", "GIF export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
