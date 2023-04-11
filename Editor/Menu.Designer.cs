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

        #region Windows Form #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.openWaveEditorButton = new System.Windows.Forms.Button();
            this.openPathEditorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(22, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(291, 21);
            this.title.TabIndex = 0;
            this.title.Text = "Welcome to Turtle Tower Defense Editor!";
            // 
            // openWaveEditorButton
            // 
            this.openWaveEditorButton.Location = new System.Drawing.Point(96, 104);
            this.openWaveEditorButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openWaveEditorButton.Name = "openWaveEditorButton";
            this.openWaveEditorButton.Size = new System.Drawing.Size(135, 46);
            this.openWaveEditorButton.TabIndex = 2;
            this.openWaveEditorButton.Text = "Open Wave Editor";
            this.openWaveEditorButton.UseVisualStyleBackColor = true;
            this.openWaveEditorButton.Click += new System.EventHandler(this.openWaveEditorButton_Click);
            // 
            // openPathEditorButton
            // 
            this.openPathEditorButton.Location = new System.Drawing.Point(96, 44);
            this.openPathEditorButton.Name = "openPathEditorButton";
            this.openPathEditorButton.Size = new System.Drawing.Size(135, 46);
            this.openPathEditorButton.TabIndex = 3;
            this.openPathEditorButton.Text = "Open Path Editor";
            this.openPathEditorButton.UseVisualStyleBackColor = true;
            this.openPathEditorButton.Click += new System.EventHandler(this.openPathEditorButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 171);
            this.Controls.Add(this.openPathEditorButton);
            this.Controls.Add(this.openWaveEditorButton);
            this.Controls.Add(this.title);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label title;
        private Button openWaveEditorButton;
        private Button openPathEditorButton;
    }
}