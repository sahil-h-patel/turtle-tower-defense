﻿namespace LevelEditor
{
    partial class Form1
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
            this.buttonLoad = new System.Windows.Forms.Button();
            this.groupBoxCreateMap = new System.Windows.Forms.GroupBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupBoxCreateMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(21, 9);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(222, 52);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load Map";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // groupBoxCreateMap
            // 
            this.groupBoxCreateMap.Controls.Add(this.textBoxWidth);
            this.groupBoxCreateMap.Controls.Add(this.textBoxHeight);
            this.groupBoxCreateMap.Controls.Add(this.labelHeight);
            this.groupBoxCreateMap.Controls.Add(this.labelWidth);
            this.groupBoxCreateMap.Controls.Add(this.buttonCreate);
            this.groupBoxCreateMap.Location = new System.Drawing.Point(21, 74);
            this.groupBoxCreateMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxCreateMap.Name = "groupBoxCreateMap";
            this.groupBoxCreateMap.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxCreateMap.Size = new System.Drawing.Size(222, 178);
            this.groupBoxCreateMap.TabIndex = 1;
            this.groupBoxCreateMap.TabStop = false;
            this.groupBoxCreateMap.Text = "Create New Map";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(117, 26);
            this.textBoxWidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(81, 23);
            this.textBoxWidth.TabIndex = 4;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(117, 64);
            this.textBoxHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(81, 23);
            this.textBoxHeight.TabIndex = 3;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(19, 66);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(88, 15);
            this.labelHeight.TabIndex = 2;
            this.labelHeight.Text = "Height (in tiles)";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(19, 28);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(84, 15);
            this.labelWidth.TabIndex = 1;
            this.labelWidth.Text = "Width (in tiles)";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(19, 103);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(183, 55);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Create Map";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 268);
            this.Controls.Add(this.groupBoxCreateMap);
            this.Controls.Add(this.buttonLoad);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Level Editor";
            this.groupBoxCreateMap.ResumeLayout(false);
            this.groupBoxCreateMap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonLoad;
        private GroupBox groupBoxCreateMap;
        private TextBox textBoxWidth;
        private TextBox textBoxHeight;
        private Label labelHeight;
        private Label labelWidth;
        private Button buttonCreate;
    }
}