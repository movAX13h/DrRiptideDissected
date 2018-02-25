namespace riptide
{
    partial class PaletteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaletteForm));
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.canvasBox = new System.Windows.Forms.PictureBox();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.indicesCheckBox = new System.Windows.Forms.CheckBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.canvasPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).BeginInit();
            this.SuspendLayout();
            // 
            // canvasPanel
            // 
            this.canvasPanel.Controls.Add(this.canvasBox);
            this.canvasPanel.Location = new System.Drawing.Point(12, 12);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(320, 320);
            this.canvasPanel.TabIndex = 0;
            // 
            // canvasBox
            // 
            this.canvasBox.Location = new System.Drawing.Point(0, 0);
            this.canvasBox.Margin = new System.Windows.Forms.Padding(0);
            this.canvasBox.Name = "canvasBox";
            this.canvasBox.Size = new System.Drawing.Size(320, 320);
            this.canvasBox.TabIndex = 0;
            this.canvasBox.TabStop = false;
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.Location = new System.Drawing.Point(12, 366);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(104, 13);
            this.rotationLabel.TabIndex = 1;
            this.rotationLabel.Text = "Palette Rotation Info";
            // 
            // indicesCheckBox
            // 
            this.indicesCheckBox.AutoSize = true;
            this.indicesCheckBox.Location = new System.Drawing.Point(12, 338);
            this.indicesCheckBox.Name = "indicesCheckBox";
            this.indicesCheckBox.Size = new System.Drawing.Size(87, 17);
            this.indicesCheckBox.TabIndex = 2;
            this.indicesCheckBox.Text = "show indices";
            this.indicesCheckBox.UseVisualStyleBackColor = true;
            this.indicesCheckBox.CheckedChanged += new System.EventHandler(this.indicesCheckBox_CheckedChanged);
            // 
            // timeLabel
            // 
            this.timeLabel.Location = new System.Drawing.Point(142, 339);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(190, 16);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "time";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PaletteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 388);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.indicesCheckBox);
            this.Controls.Add(this.rotationLabel);
            this.Controls.Add(this.canvasPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaletteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Palette";
            this.canvasPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.Label rotationLabel;
        private System.Windows.Forms.CheckBox indicesCheckBox;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.PictureBox canvasBox;
    }
}