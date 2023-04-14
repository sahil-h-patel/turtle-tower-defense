namespace Editor
{
    partial class PathEditor
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
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.pathListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.pathNameLabel = new System.Windows.Forms.Label();
            this.pathName = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.Panel();
            this.currentTile = new System.Windows.Forms.PictureBox();
            this.currentTileLabel = new System.Windows.Forms.Label();
            this.tilesLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.currentTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(14, 559);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(151, 64);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 629);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(151, 64);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // pathListView
            // 
            this.pathListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.pathListView.GridLines = true;
            this.pathListView.Location = new System.Drawing.Point(14, 16);
            this.pathListView.MultiSelect = false;
            this.pathListView.Name = "pathListView";
            this.pathListView.Size = new System.Drawing.Size(151, 340);
            this.pathListView.TabIndex = 2;
            this.pathListView.UseCompatibleStateImageBehavior = false;
            this.pathListView.View = System.Windows.Forms.View.Details;
            this.pathListView.SelectedIndexChanged += new System.EventHandler(this.pathListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Path:";
            this.columnHeader1.Width = 145;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 436);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(151, 35);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add Path";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(12, 477);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(151, 35);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove Path";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // pathNameLabel
            // 
            this.pathNameLabel.AutoSize = true;
            this.pathNameLabel.Location = new System.Drawing.Point(14, 369);
            this.pathNameLabel.Name = "pathNameLabel";
            this.pathNameLabel.Size = new System.Drawing.Size(84, 20);
            this.pathNameLabel.TabIndex = 5;
            this.pathNameLabel.Text = "Path Name:";
            // 
            // pathName
            // 
            this.pathName.Location = new System.Drawing.Point(14, 392);
            this.pathName.Name = "pathName";
            this.pathName.Size = new System.Drawing.Size(151, 27);
            this.pathName.TabIndex = 6;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(14, 519);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(151, 33);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear Path";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // path
            // 
            this.path.BackColor = System.Drawing.SystemColors.Control;
            this.path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.path.Location = new System.Drawing.Point(171, 53);
            this.path.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(1120, 640);
            this.path.TabIndex = 8;
            // 
            // currentTile
            // 
            this.currentTile.Location = new System.Drawing.Point(277, 6);
            this.currentTile.Name = "currentTile";
            this.currentTile.Size = new System.Drawing.Size(40, 40);
            this.currentTile.TabIndex = 9;
            this.currentTile.TabStop = false;
            // 
            // currentTileLabel
            // 
            this.currentTileLabel.AutoSize = true;
            this.currentTileLabel.Location = new System.Drawing.Point(183, 16);
            this.currentTileLabel.Name = "currentTileLabel";
            this.currentTileLabel.Size = new System.Drawing.Size(88, 20);
            this.currentTileLabel.TabIndex = 10;
            this.currentTileLabel.Text = "Current Tile:";
            // 
            // tilesLabel
            // 
            this.tilesLabel.AutoSize = true;
            this.tilesLabel.Location = new System.Drawing.Point(412, 16);
            this.tilesLabel.Name = "tilesLabel";
            this.tilesLabel.Size = new System.Drawing.Size(42, 20);
            this.tilesLabel.TabIndex = 11;
            this.tilesLabel.Text = "Tiles:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(469, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(541, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(613, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(686, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 40);
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // PathEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 711);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tilesLabel);
            this.Controls.Add(this.currentTileLabel);
            this.Controls.Add(this.currentTile);
            this.Controls.Add(this.path);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.pathName);
            this.Controls.Add(this.pathNameLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.pathListView);
            this.Controls.Add(this.loadButton);
            this.Name = "PathEditor";
            this.Text = "Path Editor";
            ((System.ComponentModel.ISupportInitialize)(this.currentTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button saveButton;
        private Button loadButton;
        private ListView pathListView;
        private Button addButton;
        private Button removeButton;
        private Label pathNameLabel;
        private TextBox pathName;
        private Button clearButton;
        private ColumnHeader columnHeader1;
        private Panel path;
        private PictureBox currentTile;
        private Label currentTileLabel;
        private Label tilesLabel;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}