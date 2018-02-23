using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using riptide.Controls;
using riptide.Riptide;

namespace riptide
{
    public partial class Form1 : Form
    {
        private Game game;
        private Bitmap canvas;

        private Bitmap currentBitmap = null;
        private Sprite currentSprite = null;
        private Map currentMap = null;
        private int currentSpriteFrame = 0;
        private int currentZoom = 3;

        private TilesForm tilesForm;

        public Form1()
        {
            InitializeComponent();

            tilesButton.Left = pngButton.Left;
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
            detailsTextBox.Visible = false;

            pngButton.Visible = false;
            tilesButton.Visible = false;
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
                    tilesButton.Visible = true;
                    canvasPanel.Visible = true;
                    break;

                case DatFileEntry.DataType.Text:
                    detailsTextBox.Text = entry.GetText();
                    detailsTextBox.Visible = true;
                    break;
            }

            draw();
        }

        private void start()
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
                saveAllButton.Enabled = saveGifsButton.Enabled;
            }
            else
            {
                MessageBox.Show("Failed: " + game.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Failed to load game data!";
            }
        }

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
                int cellSize = 8 * currentZoom;

                w = currentMap.Width * cellSize;
                h = currentMap.Height * cellSize;

                canvas = new Bitmap(w, h);
                gfx = Graphics.FromImage(canvas);
                gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                // map tiles
                for (y = 0; y < currentMap.Height; y++)
                {
                    for (x = 0; x < currentMap.Width; x++)
                    {
                        int i = x + y * currentMap.Width;
                        MapCell cell = currentMap.Cells[i];
                        MapTile tile = currentMap.Tiles[cell.TileID];

                        int gx = x * cellSize;
                        int gy = y * cellSize;

                        gfx.DrawImage(tile.Bitmap, new Rectangle(gx, gy, cellSize, cellSize), new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);

                        
                        if (cell.EntityID > 0)
                        {
                            gfx.FillRectangle(new SolidBrush(Color.FromArgb(150, 0, 255, 0)), new Rectangle(gx, gy, cellSize, cellSize));
                            gfx.DrawString(cell.EntityID.ToString(), SystemFonts.CaptionFont, Brushes.White, gx, gy);
                        }

                        if (cell.SolidEntityID > 0)
                        {
                            //gfx.DrawImage(currentMap.Tiles[cell.SolidEntityID].Bitmap, new Rectangle(gx, gy, cellSize, cellSize), new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
                            gfx.FillPie(new SolidBrush(Color.FromArgb(150, 255, 105, 180)), new Rectangle(gx, gy, cellSize, cellSize), 0, 360);
                            gfx.DrawString(cell.SolidEntityID.ToString(), SystemFonts.CaptionFont, Brushes.White, gx, gy);
                        }
                    }
                }

                // draw grid on top
                Pen gridPen = new Pen(Color.FromArgb(50, 0, 0, 0));

                for (x = 0; x <= currentMap.Width; x++)
                {
                    int gx = x * cellSize + 1;
                    gfx.DrawLine(gridPen, gx, 0, gx, h);
                }

                for (y = 0; y <= currentMap.Height; y++)
                {
                    int gy = y * cellSize + 1;
                    gfx.DrawLine(gridPen, 0, gy, w, gy);
                }
            }

            canvasBox.Image = canvas;
            if (gfx != null) gfx.Dispose();
        }
                
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

        private void startButton_Click(object sender, EventArgs e)
        {
            start();
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

        private void saveAllButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("unpacked")) Directory.CreateDirectory("unpacked");
            int num = 0;

            foreach (DatFileEntry file in game.Archive.Files)
            {
                File.WriteAllBytes("unpacked/" + file.Filename, file.Data);
                num++;
            }

            MessageBox.Show($"{num} files written.", "archive unpacked", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tilesButton_Click(object sender, EventArgs e)
        {
            if (currentMap == null) return;

            tilesForm = new TilesForm(currentMap);
            tilesForm.Show(this);
        }

        private void datFileList_DoubleClick(object sender, EventArgs e)
        {
            if (datFileList.SelectedItems.Count > 0)
            {
                EditForm form = new EditForm(game, ((FileListItem)datFileList.SelectedItems[0]).Entry);
                form.Show();
            }
        }
    }
}
