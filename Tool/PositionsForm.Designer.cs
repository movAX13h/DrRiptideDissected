namespace riptide
{
    partial class PositionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PositionsForm));
            this.positionsList = new System.Windows.Forms.ListView();
            this.numberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.xColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.yColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // positionsList
            // 
            this.positionsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numberColumn,
            this.xColumn,
            this.yColumn,
            this.typeColumn});
            this.positionsList.FullRowSelect = true;
            this.positionsList.Location = new System.Drawing.Point(12, 12);
            this.positionsList.Name = "positionsList";
            this.positionsList.Size = new System.Drawing.Size(425, 271);
            this.positionsList.TabIndex = 0;
            this.positionsList.UseCompatibleStateImageBehavior = false;
            this.positionsList.View = System.Windows.Forms.View.Details;
            // 
            // numberColumn
            // 
            this.numberColumn.Text = "Nr.";
            this.numberColumn.Width = 32;
            // 
            // xColumn
            // 
            this.xColumn.Text = "X";
            this.xColumn.Width = 38;
            // 
            // yColumn
            // 
            this.yColumn.Text = "Y";
            this.yColumn.Width = 39;
            // 
            // typeColumn
            // 
            this.typeColumn.Text = "Type";
            this.typeColumn.Width = 282;
            // 
            // PositionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 295);
            this.Controls.Add(this.positionsList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PositionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Positions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView positionsList;
        private System.Windows.Forms.ColumnHeader numberColumn;
        private System.Windows.Forms.ColumnHeader xColumn;
        private System.Windows.Forms.ColumnHeader yColumn;
        private System.Windows.Forms.ColumnHeader typeColumn;
    }
}