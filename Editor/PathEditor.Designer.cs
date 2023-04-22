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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathEditor));
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
            this.forwardTile = new System.Windows.Forms.PictureBox();
            this.turnRightTile = new System.Windows.Forms.PictureBox();
            this.splitTile = new System.Windows.Forms.PictureBox();
            this.sandTile = new System.Windows.Forms.PictureBox();
            this.turnLeftTile = new System.Windows.Forms.PictureBox();
            this.startTile = new System.Windows.Forms.PictureBox();
            this.endTile = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.currentTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forwardTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnRightTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sandTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnLeftTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endTile)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 521);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(165, 90);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SavePaths);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 611);
            this.loadButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(165, 90);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadPaths);
            // 
            // pathListView
            // 
            this.pathListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.pathListView.GridLines = true;
            this.pathListView.Location = new System.Drawing.Point(12, 12);
            this.pathListView.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pathListView.MultiSelect = false;
            this.pathListView.Name = "pathListView";
            this.pathListView.Size = new System.Drawing.Size(165, 505);
            this.pathListView.TabIndex = 2;
            this.pathListView.UseCompatibleStateImageBehavior = false;
            this.pathListView.View = System.Windows.Forms.View.Details;
            this.pathListView.SelectedIndexChanged += new System.EventHandler(this.ChangePath);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Path:";
            this.columnHeader1.Width = 145;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(1111, 18);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(164, 31);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add Path";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddPath);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(942, 18);
            this.removeButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(161, 31);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove Path";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemovePath);
            // 
            // pathNameLabel
            // 
            this.pathNameLabel.AutoSize = true;
            this.pathNameLabel.Location = new System.Drawing.Point(186, 22);
            this.pathNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pathNameLabel.Name = "pathNameLabel";
            this.pathNameLabel.Size = new System.Drawing.Size(69, 15);
            this.pathNameLabel.TabIndex = 5;
            this.pathNameLabel.Text = "Path Name:";
            // 
            // pathName
            // 
            this.pathName.Location = new System.Drawing.Point(263, 18);
            this.pathName.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pathName.Name = "pathName";
            this.pathName.PlaceholderText = "Name of the path";
            this.pathName.Size = new System.Drawing.Size(165, 23);
            this.pathName.TabIndex = 1;
            this.pathName.MouseLeave += new System.EventHandler(this.DeselectText);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(1283, 18);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(144, 31);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear Path";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.Clear);
            // 
            // path
            // 
            this.path.BackColor = System.Drawing.SystemColors.Control;
            this.path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.path.Location = new System.Drawing.Point(188, 61);
            this.path.Margin = new System.Windows.Forms.Padding(4);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(1240, 640);
            this.path.TabIndex = 8;
            // 
            // currentTile
            // 
            this.currentTile.Location = new System.Drawing.Point(512, 9);
            this.currentTile.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.currentTile.Name = "currentTile";
            this.currentTile.Size = new System.Drawing.Size(40, 40);
            this.currentTile.TabIndex = 9;
            this.currentTile.TabStop = false;
            // 
            // currentTileLabel
            // 
            this.currentTileLabel.AutoSize = true;
            this.currentTileLabel.Location = new System.Drawing.Point(433, 22);
            this.currentTileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentTileLabel.Name = "currentTileLabel";
            this.currentTileLabel.Size = new System.Drawing.Size(71, 15);
            this.currentTileLabel.TabIndex = 10;
            this.currentTileLabel.Text = "Current Tile:";
            // 
            // tilesLabel
            // 
            this.tilesLabel.AutoSize = true;
            this.tilesLabel.Location = new System.Drawing.Point(560, 22);
            this.tilesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tilesLabel.Name = "tilesLabel";
            this.tilesLabel.Size = new System.Drawing.Size(33, 15);
            this.tilesLabel.TabIndex = 11;
            this.tilesLabel.Text = "Tiles:";
            // 
            // forwardTile
            // 
            this.forwardTile.Image = ((System.Drawing.Image)(resources.GetObject("forwardTile.Image")));
            this.forwardTile.Location = new System.Drawing.Point(603, 11);
            this.forwardTile.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.forwardTile.Name = "forwardTile";
            this.forwardTile.Size = new System.Drawing.Size(40, 40);
            this.forwardTile.TabIndex = 12;
            this.forwardTile.TabStop = false;
            this.forwardTile.Click += new System.EventHandler(this.ChangeCurrentTileTag);
            // 
            // turnRightTile
            // 
            this.turnRightTile.Image = global::Editor.Properties.Resources.turnRightPath;
            this.turnRightTile.Location = new System.Drawing.Point(651, 11);
            this.turnRightTile.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.turnRightTile.Name = "turnRightTile";
            this.turnRightTile.Size = new System.Drawing.Size(40, 40);
            this.turnRightTile.TabIndex = 14;
            this.turnRightTile.TabStop = false;
            this.turnRightTile.Click += new System.EventHandler(this.ChangeCurrentTileTag);
            // 
            // splitTile
            // 
            this.splitTile.Image = global::Editor.Properties.Resources.splitPath;
            this.splitTile.Location = new System.Drawing.Point(745, 11);
            this.splitTile.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitTile.Name = "splitTile";
            this.splitTile.Size = new System.Drawing.Size(40, 40);
            this.splitTile.TabIndex = 15;
            this.splitTile.TabStop = false;
            this.splitTile.Click += new System.EventHandler(this.ChangeCurrentTileTag);
            // 
            // sandTile
            // 
            this.sandTile.Image = global::Editor.Properties.Resources.sandTexture;
            this.sandTile.Location = new System.Drawing.Point(793, 11);
            this.sandTile.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.sandTile.Name = "sandTile";
            this.sandTile.Size = new System.Drawing.Size(40, 40);
            this.sandTile.TabIndex = 16;
            this.sandTile.TabStop = false;
            this.sandTile.Click += new System.EventHandler(this.ChangeCurrentTileTag);
            // 
            // turnLeftTile
            // 
            this.turnLeftTile.Image = global::Editor.Properties.Resources.turnLeftPath;
            this.turnLeftTile.Location = new System.Drawing.Point(698, 11);
            this.turnLeftTile.Name = "turnLeftTile";
            this.turnLeftTile.Size = new System.Drawing.Size(40, 40);
            this.turnLeftTile.TabIndex = 17;
            this.turnLeftTile.TabStop = false;
            this.turnLeftTile.Click += new System.EventHandler(this.ChangeCurrentTileTag);
            // 
            // startTile
            // 
            this.startTile.Image = global::Editor.Properties.Resources.start;
            this.startTile.Location = new System.Drawing.Point(840, 11);
            this.startTile.Name = "startTile";
            this.startTile.Size = new System.Drawing.Size(40, 40);
            this.startTile.TabIndex = 18;
            this.startTile.TabStop = false;
            this.startTile.Click += new System.EventHandler(this.ChangeCurrentTileTag);
            // 
            // endTile
            // 
            this.endTile.Image = global::Editor.Properties.Resources.end;
            this.endTile.Location = new System.Drawing.Point(886, 11);
            this.endTile.Name = "endTile";
            this.endTile.Size = new System.Drawing.Size(40, 40);
            this.endTile.TabIndex = 19;
            this.endTile.TabStop = false;
            this.endTile.Click += new System.EventHandler(this.ChangeCurrentTileTag);
            // 
            // PathEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1440, 711);
            this.Controls.Add(this.endTile);
            this.Controls.Add(this.startTile);
            this.Controls.Add(this.turnLeftTile);
            this.Controls.Add(this.sandTile);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.splitTile);
            this.Controls.Add(this.turnRightTile);
            this.Controls.Add(this.forwardTile);
            this.Controls.Add(this.tilesLabel);
            this.Controls.Add(this.currentTileLabel);
            this.Controls.Add(this.currentTile);
            this.Controls.Add(this.path);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.pathName);
            this.Controls.Add(this.pathNameLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.pathListView);
            this.Controls.Add(this.loadButton);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "PathEditor";
            this.Text = "Path Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rotate);
            ((System.ComponentModel.ISupportInitialize)(this.currentTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forwardTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnRightTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sandTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnLeftTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endTile)).EndInit();
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
        private Label currentTileLabel;
        private Label tilesLabel;
        private PictureBox forwardTile;
        private PictureBox turnRightTile;
        private PictureBox splitTile;
        private PictureBox sandTile;
        private Panel path;
        private PictureBox currentTile;
        private PictureBox turnLeftTile;
        private PictureBox startTile;
        private PictureBox endTile;
    }
}