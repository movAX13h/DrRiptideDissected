namespace riptide
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.datFileList = new System.Windows.Forms.ListView();
            this.idColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.mapButtonsPanel = new System.Windows.Forms.Panel();
            this.paletteButton = new System.Windows.Forms.Button();
            this.positionsButton = new System.Windows.Forms.Button();
            this.spritesButton = new System.Windows.Forms.Button();
            this.tilesButton = new System.Windows.Forms.Button();
            this.selectionLabel = new System.Windows.Forms.TextBox();
            this.pngButton = new System.Windows.Forms.Button();
            this.frameSelectionPanel = new System.Windows.Forms.Panel();
            this.gifButton = new System.Windows.Forms.Button();
            this.prevFrameButton = new System.Windows.Forms.Button();
            this.nextFrameButton = new System.Windows.Forms.Button();
            this.frameLabel = new System.Windows.Forms.Label();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.canvasBox = new System.Windows.Forms.PictureBox();
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.detailsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.cursorStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.zoom10xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom9xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom8xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom7xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom6xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom5xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom4xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom3xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom2xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom1xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGifsButton = new System.Windows.Forms.Button();
            this.saveAllButton = new System.Windows.Forms.Button();
            this.selectionPanel.SuspendLayout();
            this.mapButtonsPanel.SuspendLayout();
            this.frameSelectionPanel.SuspendLayout();
            this.canvasPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datFileList
            // 
            this.datFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.datFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumn,
            this.fileColumn,
            this.typeColumn,
            this.sizeColumn});
            this.datFileList.FullRowSelect = true;
            this.datFileList.GridLines = true;
            this.datFileList.HideSelection = false;
            this.datFileList.Location = new System.Drawing.Point(12, 12);
            this.datFileList.MultiSelect = false;
            this.datFileList.Name = "datFileList";
            this.datFileList.Size = new System.Drawing.Size(334, 437);
            this.datFileList.TabIndex = 2;
            this.datFileList.UseCompatibleStateImageBehavior = false;
            this.datFileList.View = System.Windows.Forms.View.Details;
            this.datFileList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.datFileList_ColumnClick);
            this.datFileList.SelectedIndexChanged += new System.EventHandler(this.datFileList_SelectedIndexChanged);
            this.datFileList.DoubleClick += new System.EventHandler(this.datFileList_DoubleClick);
            this.datFileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datFileList_KeyDown);
            // 
            // idColumn
            // 
            this.idColumn.Text = "ID";
            this.idColumn.Width = 35;
            // 
            // fileColumn
            // 
            this.fileColumn.Text = "Filename";
            this.fileColumn.Width = 119;
            // 
            // typeColumn
            // 
            this.typeColumn.Text = "Type";
            this.typeColumn.Width = 88;
            // 
            // sizeColumn
            // 
            this.sizeColumn.Text = "Size";
            this.sizeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sizeColumn.Width = 64;
            // 
            // selectionPanel
            // 
            this.selectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectionPanel.Controls.Add(this.mapButtonsPanel);
            this.selectionPanel.Controls.Add(this.selectionLabel);
            this.selectionPanel.Controls.Add(this.pngButton);
            this.selectionPanel.Controls.Add(this.frameSelectionPanel);
            this.selectionPanel.Controls.Add(this.canvasPanel);
            this.selectionPanel.Controls.Add(this.detailsTextBox);
            this.selectionPanel.Location = new System.Drawing.Point(352, 12);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(631, 470);
            this.selectionPanel.TabIndex = 3;
            // 
            // mapButtonsPanel
            // 
            this.mapButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mapButtonsPanel.BackColor = System.Drawing.Color.Transparent;
            this.mapButtonsPanel.Controls.Add(this.paletteButton);
            this.mapButtonsPanel.Controls.Add(this.positionsButton);
            this.mapButtonsPanel.Controls.Add(this.spritesButton);
            this.mapButtonsPanel.Controls.Add(this.tilesButton);
            this.mapButtonsPanel.Location = new System.Drawing.Point(66, 3);
            this.mapButtonsPanel.Name = "mapButtonsPanel";
            this.mapButtonsPanel.Size = new System.Drawing.Size(311, 27);
            this.mapButtonsPanel.TabIndex = 6;
            this.mapButtonsPanel.Visible = false;
            // 
            // paletteButton
            // 
            this.paletteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteButton.Location = new System.Drawing.Point(248, 2);
            this.paletteButton.Name = "paletteButton";
            this.paletteButton.Size = new System.Drawing.Size(60, 23);
            this.paletteButton.TabIndex = 7;
            this.paletteButton.Text = "Palette";
            this.paletteButton.UseVisualStyleBackColor = true;
            this.paletteButton.Click += new System.EventHandler(this.paletteButton_Click);
            // 
            // positionsButton
            // 
            this.positionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.positionsButton.Location = new System.Drawing.Point(182, 2);
            this.positionsButton.Name = "positionsButton";
            this.positionsButton.Size = new System.Drawing.Size(60, 23);
            this.positionsButton.TabIndex = 6;
            this.positionsButton.Text = "Triggers";
            this.positionsButton.UseVisualStyleBackColor = true;
            this.positionsButton.Click += new System.EventHandler(this.positionsButton_Click);
            // 
            // spritesButton
            // 
            this.spritesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spritesButton.Location = new System.Drawing.Point(58, 2);
            this.spritesButton.Name = "spritesButton";
            this.spritesButton.Size = new System.Drawing.Size(61, 23);
            this.spritesButton.TabIndex = 4;
            this.spritesButton.Text = "Entities";
            this.spritesButton.UseVisualStyleBackColor = true;
            this.spritesButton.Click += new System.EventHandler(this.spritesButton_Click);
            // 
            // tilesButton
            // 
            this.tilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tilesButton.Location = new System.Drawing.Point(125, 2);
            this.tilesButton.Name = "tilesButton";
            this.tilesButton.Size = new System.Drawing.Size(51, 23);
            this.tilesButton.TabIndex = 4;
            this.tilesButton.Text = "Tiles";
            this.tilesButton.UseVisualStyleBackColor = true;
            this.tilesButton.Click += new System.EventHandler(this.tilesButton_Click);
            // 
            // selectionLabel
            // 
            this.selectionLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectionLabel.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectionLabel.Location = new System.Drawing.Point(7, 9);
            this.selectionLabel.Name = "selectionLabel";
            this.selectionLabel.ReadOnly = true;
            this.selectionLabel.Size = new System.Drawing.Size(307, 16);
            this.selectionLabel.TabIndex = 7;
            // 
            // pngButton
            // 
            this.pngButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pngButton.Location = new System.Drawing.Point(577, 6);
            this.pngButton.Name = "pngButton";
            this.pngButton.Size = new System.Drawing.Size(51, 23);
            this.pngButton.TabIndex = 3;
            this.pngButton.Text = "PNG";
            this.pngButton.UseVisualStyleBackColor = true;
            this.pngButton.Visible = false;
            this.pngButton.Click += new System.EventHandler(this.pngButton_Click);
            // 
            // frameSelectionPanel
            // 
            this.frameSelectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.frameSelectionPanel.Controls.Add(this.gifButton);
            this.frameSelectionPanel.Controls.Add(this.prevFrameButton);
            this.frameSelectionPanel.Controls.Add(this.nextFrameButton);
            this.frameSelectionPanel.Controls.Add(this.frameLabel);
            this.frameSelectionPanel.Location = new System.Drawing.Point(380, 3);
            this.frameSelectionPanel.Name = "frameSelectionPanel";
            this.frameSelectionPanel.Size = new System.Drawing.Size(196, 27);
            this.frameSelectionPanel.TabIndex = 2;
            this.frameSelectionPanel.Visible = false;
            // 
            // gifButton
            // 
            this.gifButton.Location = new System.Drawing.Point(140, 2);
            this.gifButton.Name = "gifButton";
            this.gifButton.Size = new System.Drawing.Size(51, 23);
            this.gifButton.TabIndex = 4;
            this.gifButton.Text = "GIF";
            this.gifButton.UseVisualStyleBackColor = true;
            this.gifButton.Click += new System.EventHandler(this.gifButton_Click);
            // 
            // prevFrameButton
            // 
            this.prevFrameButton.Location = new System.Drawing.Point(3, 2);
            this.prevFrameButton.Name = "prevFrameButton";
            this.prevFrameButton.Size = new System.Drawing.Size(42, 23);
            this.prevFrameButton.TabIndex = 0;
            this.prevFrameButton.Text = "<";
            this.prevFrameButton.UseVisualStyleBackColor = true;
            this.prevFrameButton.Click += new System.EventHandler(this.prevFrameButton_Click);
            // 
            // nextFrameButton
            // 
            this.nextFrameButton.Location = new System.Drawing.Point(79, 2);
            this.nextFrameButton.Name = "nextFrameButton";
            this.nextFrameButton.Size = new System.Drawing.Size(42, 23);
            this.nextFrameButton.TabIndex = 1;
            this.nextFrameButton.Text = ">";
            this.nextFrameButton.UseVisualStyleBackColor = true;
            this.nextFrameButton.Click += new System.EventHandler(this.nextFrameButton_Click);
            // 
            // frameLabel
            // 
            this.frameLabel.Location = new System.Drawing.Point(42, 3);
            this.frameLabel.Name = "frameLabel";
            this.frameLabel.Size = new System.Drawing.Size(41, 22);
            this.frameLabel.TabIndex = 2;
            this.frameLabel.Text = "1/1";
            this.frameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // canvasPanel
            // 
            this.canvasPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvasPanel.AutoScroll = true;
            this.canvasPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.canvasPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvasPanel.Controls.Add(this.canvasBox);
            this.canvasPanel.Location = new System.Drawing.Point(6, 36);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(622, 431);
            this.canvasPanel.TabIndex = 1;
            this.canvasPanel.Visible = false;
            // 
            // canvasBox
            // 
            this.canvasBox.Location = new System.Drawing.Point(0, 0);
            this.canvasBox.Margin = new System.Windows.Forms.Padding(0);
            this.canvasBox.Name = "canvasBox";
            this.canvasBox.Size = new System.Drawing.Size(578, 319);
            this.canvasBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.canvasBox.TabIndex = 0;
            this.canvasBox.TabStop = false;
            this.canvasBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasBox_MouseDown);
            this.canvasBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasBox_MouseMove);
            this.canvasBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasBox_MouseUp);
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsTextBox.Location = new System.Drawing.Point(5, 43);
            this.detailsTextBox.Multiline = true;
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.ReadOnly = true;
            this.detailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detailsTextBox.Size = new System.Drawing.Size(626, 427);
            this.detailsTextBox.TabIndex = 5;
            this.detailsTextBox.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.detailsStatusLabel,
            this.cursorStatusLabel,
            this.zoomDropDown});
            this.statusStrip1.Location = new System.Drawing.Point(0, 492);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(995, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(320, 17);
            this.statusLabel.Text = "loading...";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // detailsStatusLabel
            // 
            this.detailsStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.detailsStatusLabel.Name = "detailsStatusLabel";
            this.detailsStatusLabel.Size = new System.Drawing.Size(86, 17);
            this.detailsStatusLabel.Text = "no data loaded";
            // 
            // cursorStatusLabel
            // 
            this.cursorStatusLabel.AutoSize = false;
            this.cursorStatusLabel.Name = "cursorStatusLabel";
            this.cursorStatusLabel.Size = new System.Drawing.Size(423, 17);
            this.cursorStatusLabel.Spring = true;
            this.cursorStatusLabel.Text = "0/0";
            // 
            // zoomDropDown
            // 
            this.zoomDropDown.AutoSize = false;
            this.zoomDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.zoomDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoom10xToolStripMenuItem,
            this.zoom9xToolStripMenuItem,
            this.zoom8xToolStripMenuItem,
            this.zoom7xToolStripMenuItem,
            this.zoom6xToolStripMenuItem,
            this.zoom5xToolStripMenuItem,
            this.zoom4xToolStripMenuItem,
            this.zoom3xToolStripMenuItem,
            this.zoom2xToolStripMenuItem,
            this.zoom1xToolStripMenuItem});
            this.zoomDropDown.Image = ((System.Drawing.Image)(resources.GetObject("zoomDropDown.Image")));
            this.zoomDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomDropDown.Name = "zoomDropDown";
            this.zoomDropDown.Size = new System.Drawing.Size(120, 20);
            this.zoomDropDown.Text = "Zoom 3x";
            this.zoomDropDown.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.zoomDropDown_DropDownItemClicked);
            // 
            // zoom10xToolStripMenuItem
            // 
            this.zoom10xToolStripMenuItem.Name = "zoom10xToolStripMenuItem";
            this.zoom10xToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.zoom10xToolStripMenuItem.Text = "Zoom 10x";
            // 
            // zoom9xToolStripMenuItem
            // 
            this.zoom9xToolStripMenuItem.Name = "zoom9xToolStripMenuItem";
            this.zoom9xToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.zoom9xToolStripMenuItem.Text = "Zoom 9x";
            // 
            // zoom8xToolStripMenuItem
            // 
            this.zoom8xToolStripMenuItem.Name = "zoom8xToolStripMenuItem";
            this.zoom8xToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.zoom8xToolStripMenuItem.Text = "Zoom 8x";
            // 
            // zoom7xToolStripMenuItem
            // 
            this.zoom7xToolStripMenuItem.Name = "zoom7xToolStripMenuItem";
            this.zoom7xToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.zoom7xToolStripMenuItem.Text = "Zoom 7x";
            // 
            // zoom6xToolStripMenuItem
            // 
            this.zoom6xToolStripMenuItem.Name = "zoom6xToolStripMenuItem";
            this.zoom6xToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.zoom6xToolStripMenuItem.Text = "Zoom 6x";
            // 
            // zoom5xToolStripMenuItem
            // 
            this.zoom5xToolStripMenuItem.Name = "zoom5xToolStripMenuItem";
            this.zoom5xToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.zoom5xToolStripMenuItem.Text = "Zoom 5x";
            // 
            // zoom4xToolStripMenuItem
            // 
            this.zoom4xToolStripMenuItem.Name = "zoom4xToolStripMenuItem";
            this.zoom4xToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.zoom4xToolStripMenuItem.Text = "Zoom 4x";
            // 
            // zoom3xToolStripMenuItem
            // 
            this.zoom3xToolStripMenuItem.Name = "zoom3xToolStripMenuItem";
            this.zoom3xToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.zoom3xToolStripMenuItem.Text = "Zoom 3x";
            // 
            // zoom2xToolStripMenuItem
            // 
            this.zoom2xToolStripMenuItem.Name = "zoom2xToolStripMenuItem";
            this.zoom2xToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.zoom2xToolStripMenuItem.Text = "Zoom 2x";
            // 
            // zoom1xToolStripMenuItem
            // 
            this.zoom1xToolStripMenuItem.Name = "zoom1xToolStripMenuItem";
            this.zoom1xToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.zoom1xToolStripMenuItem.Text = "Zoom 1x";
            // 
            // saveGifsButton
            // 
            this.saveGifsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveGifsButton.Enabled = false;
            this.saveGifsButton.Location = new System.Drawing.Point(157, 455);
            this.saveGifsButton.Name = "saveGifsButton";
            this.saveGifsButton.Size = new System.Drawing.Size(189, 27);
            this.saveGifsButton.TabIndex = 5;
            this.saveGifsButton.Text = "SAVE SPRITES AS GIF";
            this.saveGifsButton.UseVisualStyleBackColor = true;
            this.saveGifsButton.Click += new System.EventHandler(this.saveGifsButton_Click);
            // 
            // saveAllButton
            // 
            this.saveAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveAllButton.Enabled = false;
            this.saveAllButton.Location = new System.Drawing.Point(12, 455);
            this.saveAllButton.Name = "saveAllButton";
            this.saveAllButton.Size = new System.Drawing.Size(139, 27);
            this.saveAllButton.TabIndex = 6;
            this.saveAllButton.Text = "SAVE ALL";
            this.saveAllButton.UseVisualStyleBackColor = true;
            this.saveAllButton.Click += new System.EventHandler(this.saveAllButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 514);
            this.Controls.Add(this.saveAllButton);
            this.Controls.Add(this.saveGifsButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.selectionPanel);
            this.Controls.Add(this.datFileList);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 550);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dr.Riptide dissected";
            this.selectionPanel.ResumeLayout(false);
            this.selectionPanel.PerformLayout();
            this.mapButtonsPanel.ResumeLayout(false);
            this.frameSelectionPanel.ResumeLayout(false);
            this.canvasPanel.ResumeLayout(false);
            this.canvasPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView datFileList;
        private System.Windows.Forms.ColumnHeader fileColumn;
        private System.Windows.Forms.ColumnHeader sizeColumn;
        private System.Windows.Forms.ColumnHeader typeColumn;
        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel detailsStatusLabel;
        private System.Windows.Forms.ToolStripDropDownButton zoomDropDown;
        private System.Windows.Forms.ToolStripMenuItem zoom1xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom10xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom9xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom8xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom7xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom6xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom5xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom4xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom3xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom2xToolStripMenuItem;
        private System.Windows.Forms.Panel frameSelectionPanel;
        private System.Windows.Forms.Button prevFrameButton;
        private System.Windows.Forms.Button nextFrameButton;
        private System.Windows.Forms.Label frameLabel;
        private System.Windows.Forms.Button pngButton;
        private System.Windows.Forms.Button gifButton;
        private System.Windows.Forms.ColumnHeader idColumn;
        private System.Windows.Forms.PictureBox canvasBox;
        private System.Windows.Forms.Button saveGifsButton;
        private System.Windows.Forms.Button tilesButton;
        private System.Windows.Forms.TextBox detailsTextBox;
        private System.Windows.Forms.Button saveAllButton;
        private System.Windows.Forms.Panel mapButtonsPanel;
        private System.Windows.Forms.Button positionsButton;
        private System.Windows.Forms.Button paletteButton;
        private System.Windows.Forms.Button spritesButton;
        private System.Windows.Forms.ToolStripStatusLabel cursorStatusLabel;
        private System.Windows.Forms.TextBox selectionLabel;
    }
}

