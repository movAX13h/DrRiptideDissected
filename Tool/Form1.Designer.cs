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
            this.startButton = new System.Windows.Forms.Button();
            this.datFileList = new System.Windows.Forms.ListView();
            this.idColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.tilesButton = new System.Windows.Forms.Button();
            this.pngButton = new System.Windows.Forms.Button();
            this.frameSelectionPanel = new System.Windows.Forms.Panel();
            this.gifButton = new System.Windows.Forms.Button();
            this.prevFrameButton = new System.Windows.Forms.Button();
            this.nextFrameButton = new System.Windows.Forms.Button();
            this.frameLabel = new System.Windows.Forms.Label();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.canvasBox = new System.Windows.Forms.PictureBox();
            this.selectionLabel = new System.Windows.Forms.Label();
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusDetailsLabel = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.mapButtonsPanel = new System.Windows.Forms.Panel();
            this.positionsButton = new System.Windows.Forms.Button();
            this.selectionPanel.SuspendLayout();
            this.frameSelectionPanel.SuspendLayout();
            this.canvasPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.mapButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(157, 37);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "LOAD GAME";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
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
            this.datFileList.Location = new System.Drawing.Point(12, 55);
            this.datFileList.MultiSelect = false;
            this.datFileList.Name = "datFileList";
            this.datFileList.Size = new System.Drawing.Size(334, 427);
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
            this.selectionPanel.Controls.Add(this.pngButton);
            this.selectionPanel.Controls.Add(this.frameSelectionPanel);
            this.selectionPanel.Controls.Add(this.canvasPanel);
            this.selectionPanel.Controls.Add(this.selectionLabel);
            this.selectionPanel.Controls.Add(this.detailsTextBox);
            this.selectionPanel.Location = new System.Drawing.Point(352, 12);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(631, 470);
            this.selectionPanel.TabIndex = 3;
            // 
            // tilesButton
            // 
            this.tilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tilesButton.Location = new System.Drawing.Point(79, 2);
            this.tilesButton.Name = "tilesButton";
            this.tilesButton.Size = new System.Drawing.Size(51, 23);
            this.tilesButton.TabIndex = 4;
            this.tilesButton.Text = "Tiles";
            this.tilesButton.UseVisualStyleBackColor = true;
            this.tilesButton.Click += new System.EventHandler(this.tilesButton_Click);
            // 
            // pngButton
            // 
            this.pngButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pngButton.Location = new System.Drawing.Point(578, 12);
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
            this.frameSelectionPanel.Location = new System.Drawing.Point(380, 10);
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
            this.canvasPanel.Location = new System.Drawing.Point(6, 43);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(622, 424);
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
            // 
            // selectionLabel
            // 
            this.selectionLabel.AutoSize = true;
            this.selectionLabel.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectionLabel.Location = new System.Drawing.Point(3, 10);
            this.selectionLabel.Name = "selectionLabel";
            this.selectionLabel.Size = new System.Drawing.Size(136, 17);
            this.selectionLabel.TabIndex = 0;
            this.selectionLabel.Text = "nothing selected";
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
            this.statusDetailsLabel,
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
            this.statusLabel.Size = new System.Drawing.Size(370, 17);
            this.statusLabel.Text = "loading...";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusDetailsLabel
            // 
            this.statusDetailsLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusDetailsLabel.Name = "statusDetailsLabel";
            this.statusDetailsLabel.Size = new System.Drawing.Size(544, 17);
            this.statusDetailsLabel.Spring = true;
            this.statusDetailsLabel.Text = "no data loaded";
            // 
            // zoomDropDown
            // 
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
            this.zoomDropDown.Size = new System.Drawing.Size(66, 20);
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
            this.saveGifsButton.Enabled = false;
            this.saveGifsButton.Location = new System.Drawing.Point(263, 12);
            this.saveGifsButton.Name = "saveGifsButton";
            this.saveGifsButton.Size = new System.Drawing.Size(83, 37);
            this.saveGifsButton.TabIndex = 5;
            this.saveGifsButton.Text = "SAVE GIFS";
            this.saveGifsButton.UseVisualStyleBackColor = true;
            this.saveGifsButton.Click += new System.EventHandler(this.saveGifsButton_Click);
            // 
            // saveAllButton
            // 
            this.saveAllButton.Enabled = false;
            this.saveAllButton.Location = new System.Drawing.Point(175, 12);
            this.saveAllButton.Name = "saveAllButton";
            this.saveAllButton.Size = new System.Drawing.Size(83, 37);
            this.saveAllButton.TabIndex = 6;
            this.saveAllButton.Text = "SAVE ALL";
            this.saveAllButton.UseVisualStyleBackColor = true;
            this.saveAllButton.Click += new System.EventHandler(this.saveAllButton_Click);
            // 
            // mapButtonsPanel
            // 
            this.mapButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mapButtonsPanel.Controls.Add(this.positionsButton);
            this.mapButtonsPanel.Controls.Add(this.tilesButton);
            this.mapButtonsPanel.Location = new System.Drawing.Point(247, 10);
            this.mapButtonsPanel.Name = "mapButtonsPanel";
            this.mapButtonsPanel.Size = new System.Drawing.Size(130, 27);
            this.mapButtonsPanel.TabIndex = 6;
            this.mapButtonsPanel.Visible = false;
            // 
            // positionsButton
            // 
            this.positionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.positionsButton.Location = new System.Drawing.Point(13, 2);
            this.positionsButton.Name = "positionsButton";
            this.positionsButton.Size = new System.Drawing.Size(60, 23);
            this.positionsButton.TabIndex = 6;
            this.positionsButton.Text = "Positions";
            this.positionsButton.UseVisualStyleBackColor = true;
            this.positionsButton.Click += new System.EventHandler(this.positionsButton_Click);
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
            this.Controls.Add(this.startButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dr.Riptide dissected";
            this.selectionPanel.ResumeLayout(false);
            this.selectionPanel.PerformLayout();
            this.frameSelectionPanel.ResumeLayout(false);
            this.canvasPanel.ResumeLayout(false);
            this.canvasPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mapButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ListView datFileList;
        private System.Windows.Forms.ColumnHeader fileColumn;
        private System.Windows.Forms.ColumnHeader sizeColumn;
        private System.Windows.Forms.ColumnHeader typeColumn;
        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.Label selectionLabel;
        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusDetailsLabel;
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
    }
}

