namespace riptide
{
    partial class TilesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilesForm));
            this.canvasBox = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvasBox
            // 
            this.canvasBox.Location = new System.Drawing.Point(0, 0);
            this.canvasBox.Margin = new System.Windows.Forms.Padding(0);
            this.canvasBox.Name = "canvasBox";
            this.canvasBox.Size = new System.Drawing.Size(326, 225);
            this.canvasBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.canvasBox.TabIndex = 0;
            this.canvasBox.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.zoomDropDown});
            this.statusStrip1.Location = new System.Drawing.Point(0, 350);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(973, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(892, 17);
            this.statusLabel.Spring = true;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.canvasBox);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 350);
            this.panel1.TabIndex = 2;
            // 
            // TilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 372);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TilesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile set";
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvasBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton zoomDropDown;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem zoom6xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom5xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom4xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom10xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom9xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom8xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom7xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom3xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom2xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom1xToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}