namespace riptide
{
    partial class SpritesForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpritesForm));
            this.spritesList = new System.Windows.Forms.ListView();
            this.valueColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.xColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.yColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.assignmentColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.infoColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // spritesList
            // 
            this.spritesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spritesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.valueColumn,
            this.xColumn,
            this.yColumn,
            this.typeColumn,
            this.assignmentColumn,
            this.infoColumn});
            this.spritesList.FullRowSelect = true;
            this.spritesList.GridLines = true;
            this.spritesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.spritesList.LabelWrap = false;
            this.spritesList.Location = new System.Drawing.Point(12, 38);
            this.spritesList.MultiSelect = false;
            this.spritesList.Name = "spritesList";
            this.spritesList.ShowGroups = false;
            this.spritesList.Size = new System.Drawing.Size(619, 507);
            this.spritesList.SmallImageList = this.imageList;
            this.spritesList.TabIndex = 0;
            this.spritesList.UseCompatibleStateImageBehavior = false;
            this.spritesList.View = System.Windows.Forms.View.Details;
            // 
            // valueColumn
            // 
            this.valueColumn.Text = "Value";
            this.valueColumn.Width = 90;
            // 
            // xColumn
            // 
            this.xColumn.Text = "X";
            // 
            // yColumn
            // 
            this.yColumn.Text = "Y";
            // 
            // typeColumn
            // 
            this.typeColumn.Text = "Type";
            // 
            // assignmentColumn
            // 
            this.assignmentColumn.Text = "Assignment";
            this.assignmentColumn.Width = 103;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "icon.ico");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(622, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "This list shows all map cells where entity ID or shootable ID is used. Assignment" +
    " and functionality is hardcoded in the game exe.";
            // 
            // infoColumn
            // 
            this.infoColumn.Text = "Info";
            this.infoColumn.Width = 218;
            // 
            // SpritesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 557);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spritesList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpritesForm";
            this.Text = "Entities";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView spritesList;
        private System.Windows.Forms.ColumnHeader xColumn;
        private System.Windows.Forms.ColumnHeader valueColumn;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader yColumn;
        private System.Windows.Forms.ColumnHeader typeColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader assignmentColumn;
        private System.Windows.Forms.ColumnHeader infoColumn;
    }
}