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
            this.infoLabel = new System.Windows.Forms.Label();
            this.indicesCheckBox = new System.Windows.Forms.CheckBox();
            this.canvasPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).BeginInit();
            this.SuspendLayout();
            // 
            // canvasPanel
            // 
            this.canvasPanel.Controls.Add(this.canvasBox);
            this.canvasPanel.Location = new System.Drawing.Point(12, 12);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(160, 640);
            this.canvasPanel.TabIndex = 0;
            // 
            // canvasBox
            // 
            this.canvasBox.Location = new System.Drawing.Point(0, 0);
            this.canvasBox.Margin = new System.Windows.Forms.Padding(0);
            this.canvasBox.Name = "canvasBox";
            this.canvasBox.Size = new System.Drawing.Size(160, 640);
            this.canvasBox.TabIndex = 0;
            this.canvasBox.TabStop = false;
            // 
            // infoLabel
            // 
            this.infoLabel.Location = new System.Drawing.Point(73, 659);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(104, 17);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "info";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // indicesCheckBox
            // 
            this.indicesCheckBox.AutoSize = true;
            this.indicesCheckBox.Location = new System.Drawing.Point(12, 658);
            this.indicesCheckBox.Name = "indicesCheckBox";
            this.indicesCheckBox.Size = new System.Drawing.Size(87, 17);
            this.indicesCheckBox.TabIndex = 2;
            this.indicesCheckBox.Text = "show indices";
            this.indicesCheckBox.UseVisualStyleBackColor = true;
            this.indicesCheckBox.CheckedChanged += new System.EventHandler(this.indicesCheckBox_CheckedChanged);
            // 
            // PaletteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 682);
            this.Controls.Add(this.indicesCheckBox);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.canvasPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaletteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Palette";
            this.TopMost = true;
            this.canvasPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.CheckBox indicesCheckBox;
        private System.Windows.Forms.PictureBox canvasBox;
    }
}