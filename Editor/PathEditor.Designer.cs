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
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(10, 276);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(132, 40);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(10, 320);
            this.loadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(132, 40);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // pathListView
            // 
            this.pathListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.pathListView.GridLines = true;
            this.pathListView.Location = new System.Drawing.Point(12, 12);
            this.pathListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pathListView.MultiSelect = false;
            this.pathListView.Name = "pathListView";
            this.pathListView.Size = new System.Drawing.Size(133, 256);
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
            this.addButton.Location = new System.Drawing.Point(361, 10);
            this.addButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(110, 26);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add Path";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(477, 9);
            this.removeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(122, 26);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove Path";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // pathNameLabel
            // 
            this.pathNameLabel.AutoSize = true;
            this.pathNameLabel.Location = new System.Drawing.Point(149, 15);
            this.pathNameLabel.Name = "pathNameLabel";
            this.pathNameLabel.Size = new System.Drawing.Size(69, 15);
            this.pathNameLabel.TabIndex = 5;
            this.pathNameLabel.Text = "Path Name:";
            // 
            // pathName
            // 
            this.pathName.Location = new System.Drawing.Point(224, 12);
            this.pathName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pathName.Name = "pathName";
            this.pathName.Size = new System.Drawing.Size(133, 23);
            this.pathName.TabIndex = 6;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(605, 10);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(105, 25);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear Path";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // path
            // 
            this.path.BackColor = System.Drawing.SystemColors.Control;
            this.path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.path.Location = new System.Drawing.Point(150, 40);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(560, 320);
            this.path.TabIndex = 8;
            // 
            // PathEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 367);
            this.Controls.Add(this.path);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.pathName);
            this.Controls.Add(this.pathNameLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.pathListView);
            this.Controls.Add(this.loadButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PathEditor";
            this.Text = "Path Editor";
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
    }
}