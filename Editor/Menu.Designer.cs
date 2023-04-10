namespace Editor
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.openLevelEditorButton = new System.Windows.Forms.Button();
            this.openWaveEditorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(366, 28);
            this.title.TabIndex = 0;
            this.title.Text = "Welcome to Turtle Tower Defense Editor!";
            // 
            // openLevelEditorButton
            // 
            this.openLevelEditorButton.Location = new System.Drawing.Point(110, 72);
            this.openLevelEditorButton.Name = "openLevelEditorButton";
            this.openLevelEditorButton.Size = new System.Drawing.Size(154, 61);
            this.openLevelEditorButton.TabIndex = 1;
            this.openLevelEditorButton.Text = "Open Level Editor";
            this.openLevelEditorButton.UseVisualStyleBackColor = true;
            this.openLevelEditorButton.Click += new System.EventHandler(this.openLevelEditorButton_Click);
            // 
            // openWaveEditorButton
            // 
            this.openWaveEditorButton.Location = new System.Drawing.Point(110, 139);
            this.openWaveEditorButton.Name = "openWaveEditorButton";
            this.openWaveEditorButton.Size = new System.Drawing.Size(154, 61);
            this.openWaveEditorButton.TabIndex = 2;
            this.openWaveEditorButton.Text = "Open Wave Editor";
            this.openWaveEditorButton.UseVisualStyleBackColor = true;
            this.openWaveEditorButton.Click += new System.EventHandler(this.openWaveEditorButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 228);
            this.Controls.Add(this.openWaveEditorButton);
            this.Controls.Add(this.openLevelEditorButton);
            this.Controls.Add(this.title);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label title;
        private Button openLevelEditorButton;
        private Button openWaveEditorButton;
    }
}