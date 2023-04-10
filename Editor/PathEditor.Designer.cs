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
            this.path = new System.Windows.Forms.GroupBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.pathNameLabel = new System.Windows.Forms.Label();
            this.pathName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 322);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(151, 54);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 378);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(151, 54);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // pathListView
            // 
            this.pathListView.Location = new System.Drawing.Point(12, 16);
            this.pathListView.Name = "pathListView";
            this.pathListView.Size = new System.Drawing.Size(151, 248);
            this.pathListView.TabIndex = 2;
            this.pathListView.UseCompatibleStateImageBehavior = false;
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(169, 6);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(619, 426);
            this.path.TabIndex = 3;
            this.path.TabStop = false;
            this.path.Text = "Path";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(22, 226);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(21, 29);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(133, 226);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(19, 29);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "-";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // pathNameLabel
            // 
            this.pathNameLabel.AutoSize = true;
            this.pathNameLabel.Location = new System.Drawing.Point(12, 270);
            this.pathNameLabel.Name = "pathNameLabel";
            this.pathNameLabel.Size = new System.Drawing.Size(84, 20);
            this.pathNameLabel.TabIndex = 5;
            this.pathNameLabel.Text = "Path Name:";
            // 
            // pathName
            // 
            this.pathName.Location = new System.Drawing.Point(12, 293);
            this.pathName.Name = "pathName";
            this.pathName.Size = new System.Drawing.Size(151, 27);
            this.pathName.TabIndex = 6;
            // 
            // PathEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pathName);
            this.Controls.Add(this.pathNameLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.path);
            this.Controls.Add(this.pathListView);
            this.Controls.Add(this.loadButton);
            this.Name = "PathEditor";
            this.Text = "PathEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button saveButton;
        private Button loadButton;
        private ListView pathListView;
        private GroupBox path;
        private Button addButton;
        private Button removeButton;
        private Label pathNameLabel;
        private TextBox pathName;
    }
}