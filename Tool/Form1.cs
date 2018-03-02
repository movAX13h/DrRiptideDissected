using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private int scrollPosX = 0;
        private int scrollPosY = 0;
        private int dragLastX;
        private int dragLastY;
        private bool dragging = false;
        private Light[] cmfPlayerLights;

        private CmfPlayer.Playback musicPlayback;
        private Timer cmfPlayerTimer;

        public Form1()
        {
            InitializeComponent();

            initCmfPlayer();
            mapButtonsPanel.Left = pngButton.Right - mapButtonsPanel.Width;
            cmfPlayerPanel.Visible = false;
            statusLabel.Text = "";
            detailsStatusLabel.Text = "";
            datFileList.ListViewItemSorter = new ListViewColumnSorter();
            game = new Game();

            if (File.Exists(Game.ArchiveFile)) start();
            else MessageBox.Show($"Archive file '{Game.ArchiveFile}' not found. Please make sure it is available (can be from any version of the game) and restart the application.", "DAT file not found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void showFileDetails(DatFileEntry entry)
        {
            selectionLabel.Text = "";
            detailsStatusLabel.Text = "";
            cursorStatusLabel.Text = "";
            currentBitmap = null;
            currentSprite = null;
            currentMap = null;
            canvasPanel.Visible = false;
            detailsTextBox.Visible = false;

            pngButton.Visible = false;
            mapButtonsPanel.Visible = false;
            frameSelectionPanel.Visible = false;

            cmfPlayerPanel.Visible = false;
            stopMusicPlayback();

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

                    detailsStatusLabel.Text = $"Frame size: {currentBitmap.Width}x{currentBitmap.Height}";
                    
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
                        detailsStatusLabel.Text = $"Image size: {currentBitmap.Width}x{currentBitmap.Height}";
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

                    Game.MapInfo info = Game.InfoByFilename(currentMap.Entry.Filename);
                    selectionLabel.Text += $" - \"{info.Title}\"";
                    detailsStatusLabel.Text = $"Size: {currentMap.Width}x{currentMap.Height}, Password: \"{info.Password}\", Music: {info.Music}";

                    mapButtonsPanel.Visible = true;
                    canvasPanel.Visible = true;
                    break;

                case DatFileEntry.DataType.Music:
                    try
                    {
                        startMusicPlayback(entry.Data);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Failed to load CMF music: " + e.Message, "Audio failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

                statusLabel.Text = $"[{game.Archive.Files.Count} items] double-click to open in hex editor";
                detailsStatusLabel.Text = "Select an item to show details.";
                saveGifsButton.Enabled = game.Archive.Files.Count > 0;
                saveAllButton.Enabled = saveGifsButton.Enabled;

                if (datFileList.Items.Count > 0) datFileList.Items[0].Selected = true;

                /*ListViewColumnSorter sorter = datFileList.ListViewItemSorter as ListViewColumnSorter;
                sorter.SortColumn = 1;
                sorter.Order = SortOrder.Ascending;
                datFileList.Sort();

                sorter.SortColumn = 2;
                sorter.Order = SortOrder.Ascending;
                datFileList.Sort();*/
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

            int x, y, w, h, gx, gy, i;
            Graphics gfx = null;

            Font font = new Font(SystemFonts.DefaultFont.FontFamily, 9, FontStyle.Regular);

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
                        i = x + y * currentMap.Width;
                        MapCell cell = currentMap.Cells[i];
                        MapTile tile = currentMap.Tiles[cell.TileID];

                        gx = x * cellSize;
                        gy = y * cellSize;

                        gfx.DrawImage(tile.Bitmap, new Rectangle(gx, gy, cellSize, cellSize), new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);

                        if (cell.EntityID > 0)
                        {
                            Color col = Game.EntitySpriteName(cell.EntityID, x % 2 == 0).Length == 0 ? Color.Red : Color.FromArgb(150, 0, 255, 0);
                            gfx.FillRectangle(new SolidBrush(col), new Rectangle(gx, gy, cellSize, cellSize));
                        }

                        if (cell.ShootableID > 0)
                        {
                            //gfx.DrawImage(currentMap.Tiles[cell.SolidEntityID].Bitmap, new Rectangle(gx, gy, cellSize, cellSize), new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
                            Color col = Game.ShootableSpriteName(cell.ShootableID, x % 2 == 0).Length == 0 ? Color.Red : Color.FromArgb(150, 255, 105, 180);
                            gfx.FillPie(new SolidBrush(col), new Rectangle(gx, gy, cellSize, cellSize), 0, 360);
                        }
                    }
                } 
                
                // texts on top
                for (y = 0; y < currentMap.Height; y++)
                {
                    for (x = 0; x < currentMap.Width; x++)
                    {
                        i = x + y * currentMap.Width;
                        MapCell cell = currentMap.Cells[i];
                        MapTile tile = currentMap.Tiles[cell.TileID];

                        gx = x * cellSize;
                        gy = y * cellSize;

                        if (cell.EntityID > 0)
                        {
                            string info = Game.EntitySpriteName(cell.EntityID, x % 2 == 0);
                            if (info.Length == 0) info = cell.EntityID.ToString();
                            gfx.DrawString("entity: " + info, font, Brushes.White, gx, gy);
                        }

                        if (cell.ShootableID > 0)
                        {
                            string info = Game.ShootableSpriteName(cell.ShootableID, gx % 2 == 0);
                            if (info.Length == 0) info = cell.ShootableID.ToString();
                            gfx.DrawString("shootable: " + info, font, Brushes.White, gx, gy);
                        }
                    }
                }

                // positions
                for (i = 0; i < currentMap.Triggers.Length; i++)
                {
                    int pos = currentMap.Triggers[i];
                    if (pos == 0) continue;

                    string caption = Game.TriggerEntryTypeByNumber(i, pos);
                    if (i >= 30) 
                    {
                        if (i % 2 == 1) continue; // don't draw message entries containing text id instead of position (see Map.PositionEntryTypeByNumber)
                        caption = Game.TriggerEntryTypeByNumber(i + 1, currentMap.Triggers[i + 1]);
                    }

                    gx = cellSize * (pos % currentMap.Width);
                    gy = cellSize * (pos / currentMap.Width);
                    gfx.FillPie(new SolidBrush(Color.FromArgb(160, 255, 255, 0)), new Rectangle(gx, gy, cellSize, cellSize), 0, 360);
                    
                    var size = gfx.MeasureString(caption, font);
                    x = (int)Math.Min(currentMap.Width * cellSize - size.Width, Math.Max(0, gx + cellSize / 2 - size.Width / 2));
                    gfx.DrawString(caption, font, Brushes.Black, x + 1, gy + 2 + 1);
                    gfx.DrawString(caption, font, Brushes.White, x    , gy + 2    );

                    // connect teleports with a line
                    if (i >= 10 && i < 30 && i % 2 == 1)
                    {
                        int prevPos = currentMap.Triggers[i - 1];
                        int halfSize = cellSize / 2;
                        gfx.DrawLine(Pens.Yellow, cellSize * (prevPos % currentMap.Width) + halfSize, cellSize * (prevPos / currentMap.Width) + halfSize, gx + halfSize, gy + halfSize);
                    }
                }

                // draw grid on top
                Pen gridPen = new Pen(Color.FromArgb(50, 0, 0, 0));

                for (x = 0; x <= currentMap.Width; x++)
                {
                    gx = x * cellSize;
                    gfx.DrawLine(gridPen, gx, 0, gx, h);
                }

                for (y = 0; y <= currentMap.Height; y++)
                {
                    gy = y * cellSize;
                    gfx.DrawLine(gridPen, 0, gy, w, gy);
                }
            }

            canvasBox.Image = canvas;
            if (gfx != null) gfx.Dispose();
            font.Dispose();
        }
                
        private void prevFrame()
        {
            if (currentSprite.Frames.Length == 1) return;

            currentSpriteFrame--;
            if (currentSpriteFrame < 0) currentSpriteFrame = currentSprite.Frames.Length - 1;

            currentBitmap = currentSprite.Frames[currentSpriteFrame];
            draw();

            frameLabel.Text = (currentSpriteFrame + 1) + "/" + currentSprite.Frames.Length;
            detailsStatusLabel.Text = $"Frame size: {currentBitmap.Width}x{currentBitmap.Height}";
        }
        
        private void nextFrame()
        {
            if (currentSprite.Frames.Length == 1) return;

            currentSpriteFrame++;
            if (currentSpriteFrame >= currentSprite.Frames.Length) currentSpriteFrame = 0;

            currentBitmap = currentSprite.Frames[currentSpriteFrame];
            draw();

            frameLabel.Text = (currentSpriteFrame + 1) + "/" + currentSprite.Frames.Length;
            detailsStatusLabel.Text = $"Frame size: {currentBitmap.Width}x{currentBitmap.Height}";
        }

        #region music player
        private void initCmfPlayer()
        {
            cmfPlayerTimer = new Timer();
            cmfPlayerTimer.Interval = 10;
            cmfPlayerTimer.Tick += cmfPlayerTimerTick;
            cmfPlayerLights = new Light[] { light1, light2, light3, light4, light5, light6, light7, light8, light9 };
            foreach (var light in cmfPlayerLights) cmfPlayerTimer.Tick += light.Tick;
        }

        private void cmfPlayerTimerTick(object sender, EventArgs e)
        {
            cmfPlayerTimeLabel.Text = formatSeconds((int)musicPlayback.SecPosition) + " / " + formatSeconds((int)musicPlayback.SecTotal);
        }

        static string formatSeconds(int s)
        {
            return (s / 60).ToString("D2") + ":" + (s % 60).ToString("D2");
        }

        private void startMusicPlayback(byte[] data)
        {
            CmfPlayer.Cmf cmf = new CmfPlayer.Cmf(data);
            musicPlayback = new CmfPlayer.Playback(cmf);
            musicPlayback.ChannelActivity = (time, channel, velocity) =>
            {
                cmfPlayerLights[channel].val = Math.Min(velocity + .5f, 1);
            };

            cmfPlayerTimeLabel.Text = "00:00 / 00:00";
            cmfPlayerButton.Text = "PLAY";
            cmfPlayerPanel.Visible = true;

            foreach (var light in cmfPlayerLights) light.Reset();
        }

        private void stopMusicPlayback()
        {
            if (musicPlayback == null) return;
            
            musicPlayback.Close();
            musicPlayback = null;
        }

        private void cmfPlayerButton_Click(object sender, EventArgs e)
        {
            if (musicPlayback.IsPlaying)
            {
                musicPlayback.Pause();
                cmfPlayerTimer.Stop();
            }
            else
            {
                musicPlayback.Play();
                cmfPlayerTimer.Start();
            }

            if (musicPlayback.IsPlaying) cmfPlayerButton.Text = "PAUSE";
            else cmfPlayerButton.Text = "PLAY";
        }
        #endregion

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
            string outDir = "unpacked";
            if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);
            int num = 0;

            foreach (DatFileEntry file in game.Archive.Files)
            {
                File.WriteAllBytes(outDir + "/" + file.Filename, file.Data);
                num++;
            }

            MessageBox.Show($"{num} files written.", "archive unpacked", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start(Path.GetFullPath(outDir));
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
            string outDir = "exports";

            if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);
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

                    if (!sprite.SaveAsGif(outDir + "/" + Path.GetFileNameWithoutExtension(file.Filename) + ".gif"))
                    {
                        MessageBox.Show($"Failed to make GIF for '{file.Filename}': " + sprite.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        failed++;
                        continue;
                    }
                    else num++;
                }
            }

            MessageBox.Show($"{num} GIFs written.\n{failed} failed.", "GIF export", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start(Path.GetFullPath(outDir));
        }

        private void tilesButton_Click(object sender, EventArgs e)
        {
            if (currentMap == null) return;

            TilesForm tilesForm = new TilesForm(currentMap);
            tilesForm.Text = "Tiles " + currentMap.Entry.Filename;
            tilesForm.Show();
        }

        private void datFileList_DoubleClick(object sender, EventArgs e)
        {
            if (datFileList.SelectedItems.Count > 0)
            {
                var entry = ((FileListItem)datFileList.SelectedItems[0]).Entry;
                EditForm form = new EditForm(game, entry);
                form.Text = entry.Filename;
                form.Show();
            }
        }

        private void positionsButton_Click(object sender, EventArgs e)
        {
            TriggersForm form = new TriggersForm(currentMap);
            form.Text = "Triggers/Positions/Texts " + currentMap.Entry.Filename;
            form.Show();
        }

        private void paletteButton_Click(object sender, EventArgs e)
        {
            PaletteForm form = new PaletteForm(currentMap);
            form.Text = "Palette " + currentMap.Entry.Filename;
            form.Show();
        }

        private void spritesButton_Click(object sender, EventArgs e)
        {
            SpritesForm form = new SpritesForm(currentMap, game);
            form.Text = "Entities " + currentMap.Entry.Filename;
            form.Show();
        }

        #region mouse dragging map
        private void canvasBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point global = canvasBox.PointToScreen(e.Location);
            dragLastX = global.X;
            dragLastY = global.Y;

            scrollPosX = -canvasPanel.AutoScrollPosition.X;
            scrollPosY = -canvasPanel.AutoScrollPosition.Y;

            dragging = true;
        }

        private void canvasBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentMap == null) return;

            Point global = canvasBox.PointToScreen(e.Location);

            if (dragging)
            {
                canvasBox.Cursor = Cursors.SizeAll;

                int dx = global.X - dragLastX;
                int dy = global.Y - dragLastY;
                scrollPosX -= dx;
                scrollPosY -= dy;

                Point p = canvasPanel.AutoScrollPosition;
                p.X = scrollPosX;
                p.Y = scrollPosY;
                canvasPanel.AutoScrollPosition = p;
            }

            dragLastX = global.X;
            dragLastY = global.Y;

            int gx = e.Location.X / (currentZoom * 8);
            int gy = e.Location.Y / (currentZoom * 8);

            int id = gx + gy * currentMap.Width;
            if (id < currentMap.Cells.Length)
            {
                MapCell cell = currentMap.Cells[id];

                string text = "tile " + cell.TileID.ToString();

                if (cell.EntityID > 0)
                {
                    text += " entity " + cell.EntityID;
                    string info = Game.EntitySpriteName(cell.EntityID, gx % 2 == 0);
                    if (info.Length > 0) text += " - " + info;
                    info = Game.EntityInfo(cell.EntityID, gx % 2 == 0);
                    if (info.Length > 0) text += " - " + info;
                }
                if (cell.ShootableID > 0)
                {
                    text += " shootable " + cell.ShootableID;
                    string info = Game.ShootableSpriteName(cell.ShootableID, gx % 2 == 0);
                    if (info.Length > 0) text += " - " + info;
                    info = Game.ShootableInfo(cell.ShootableID, gx % 2 == 0);
                    if (info.Length > 0) text += " - " + info;
                }

                cursorStatusLabel.Text = $"{text} @ {gx}/{gy}";
            }
        }

        private void canvasBox_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            canvasBox.Cursor = Cursors.Default;
        }

        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopMusicPlayback();
        }


    }
}
