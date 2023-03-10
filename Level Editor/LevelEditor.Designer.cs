namespace LevelEditor
{
    partial class LevelEditor
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
            this.groupBoxTileSelector = new System.Windows.Forms.GroupBox();
            this.buttonBlack = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonBrown = new System.Windows.Forms.Button();
            this.buttonGrey = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.groupBoxCurrentTile = new System.Windows.Forms.GroupBox();
            this.pictureBoxCurrentColor = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.groupBoxMap = new System.Windows.Forms.GroupBox();
            this.groupBoxTileSelector.SuspendLayout();
            this.groupBoxCurrentTile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentColor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxTileSelector
            // 
            this.groupBoxTileSelector.Controls.Add(this.buttonBlack);
            this.groupBoxTileSelector.Controls.Add(this.buttonBlue);
            this.groupBoxTileSelector.Controls.Add(this.buttonRed);
            this.groupBoxTileSelector.Controls.Add(this.buttonBrown);
            this.groupBoxTileSelector.Controls.Add(this.buttonGrey);
            this.groupBoxTileSelector.Controls.Add(this.buttonGreen);
            this.groupBoxTileSelector.Location = new System.Drawing.Point(11, 9);
            this.groupBoxTileSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxTileSelector.Name = "groupBoxTileSelector";
            this.groupBoxTileSelector.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxTileSelector.Size = new System.Drawing.Size(100, 142);
            this.groupBoxTileSelector.TabIndex = 0;
            this.groupBoxTileSelector.TabStop = false;
            this.groupBoxTileSelector.Text = "Tile Selector";
            // 
            // buttonBlack
            // 
            this.buttonBlack.BackColor = System.Drawing.Color.Black;
            this.buttonBlack.Location = new System.Drawing.Point(53, 94);
            this.buttonBlack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBlack.Name = "buttonBlack";
            this.buttonBlack.Size = new System.Drawing.Size(41, 33);
            this.buttonBlack.TabIndex = 5;
            this.buttonBlack.UseVisualStyleBackColor = false;
            this.buttonBlack.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonBlue.Location = new System.Drawing.Point(5, 94);
            this.buttonBlue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(41, 33);
            this.buttonBlue.TabIndex = 4;
            this.buttonBlue.UseVisualStyleBackColor = false;
            this.buttonBlue.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonRed
            // 
            this.buttonRed.BackColor = System.Drawing.Color.Crimson;
            this.buttonRed.Location = new System.Drawing.Point(53, 57);
            this.buttonRed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(41, 33);
            this.buttonRed.TabIndex = 3;
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonBrown
            // 
            this.buttonBrown.BackColor = System.Drawing.Color.Peru;
            this.buttonBrown.Location = new System.Drawing.Point(5, 57);
            this.buttonBrown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBrown.Name = "buttonBrown";
            this.buttonBrown.Size = new System.Drawing.Size(41, 33);
            this.buttonBrown.TabIndex = 2;
            this.buttonBrown.UseVisualStyleBackColor = false;
            this.buttonBrown.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonGrey
            // 
            this.buttonGrey.BackColor = System.Drawing.Color.DarkGray;
            this.buttonGrey.Location = new System.Drawing.Point(53, 20);
            this.buttonGrey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGrey.Name = "buttonGrey";
            this.buttonGrey.Size = new System.Drawing.Size(41, 33);
            this.buttonGrey.TabIndex = 1;
            this.buttonGrey.UseVisualStyleBackColor = false;
            this.buttonGrey.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.BackColor = System.Drawing.Color.Green;
            this.buttonGreen.Location = new System.Drawing.Point(5, 20);
            this.buttonGreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(41, 33);
            this.buttonGreen.TabIndex = 0;
            this.buttonGreen.UseVisualStyleBackColor = false;
            this.buttonGreen.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // groupBoxCurrentTile
            // 
            this.groupBoxCurrentTile.Controls.Add(this.pictureBoxCurrentColor);
            this.groupBoxCurrentTile.Location = new System.Drawing.Point(10, 155);
            this.groupBoxCurrentTile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxCurrentTile.Name = "groupBoxCurrentTile";
            this.groupBoxCurrentTile.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxCurrentTile.Size = new System.Drawing.Size(101, 90);
            this.groupBoxCurrentTile.TabIndex = 1;
            this.groupBoxCurrentTile.TabStop = false;
            this.groupBoxCurrentTile.Text = "Current Tile";
            // 
            // pictureBoxCurrentColor
            // 
            this.pictureBoxCurrentColor.Location = new System.Drawing.Point(24, 26);
            this.pictureBoxCurrentColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxCurrentColor.Name = "pictureBoxCurrentColor";
            this.pictureBoxCurrentColor.Size = new System.Drawing.Size(55, 46);
            this.pictureBoxCurrentColor.TabIndex = 0;
            this.pictureBoxCurrentColor.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(10, 250);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 65);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save File";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(10, 442);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(100, 65);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Load File";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // groupBoxMap
            // 
            this.groupBoxMap.Location = new System.Drawing.Point(116, 9);
            this.groupBoxMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxMap.Name = "groupBoxMap";
            this.groupBoxMap.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxMap.Size = new System.Drawing.Size(500, 500);
            this.groupBoxMap.TabIndex = 4;
            this.groupBoxMap.TabStop = false;
            this.groupBoxMap.Text = "Map";
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 518);
            this.Controls.Add(this.groupBoxMap);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxCurrentTile);
            this.Controls.Add(this.groupBoxTileSelector);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LevelEditor";
            this.Text = "Level Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LevelEditor_FormClosing);
            this.groupBoxTileSelector.ResumeLayout(false);
            this.groupBoxCurrentTile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxTileSelector;
        private Button buttonBlack;
        private Button buttonBlue;
        private Button buttonRed;
        private Button buttonBrown;
        private Button buttonGrey;
        private Button buttonGreen;
        private GroupBox groupBoxCurrentTile;
        private PictureBox pictureBoxCurrentColor;
        private Button buttonSave;
        private Button buttonLoad;
        private GroupBox groupBoxMap;
    }
}