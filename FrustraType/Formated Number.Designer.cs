﻿namespace FrustraType
{
    partial class Formated_Number
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            textBox5 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Format";
            textBox1.Size = new Size(474, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 41);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Separator";
            textBox2.Size = new Size(154, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(172, 41);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Start";
            textBox3.Size = new Size(90, 23);
            textBox3.TabIndex = 2;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(268, 41);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "End";
            textBox4.Size = new Size(88, 23);
            textBox4.TabIndex = 3;
            textBox4.KeyPress += textBox4_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(411, 70);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(362, 41);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Interval Size";
            textBox5.Size = new Size(124, 23);
            textBox5.TabIndex = 5;
            textBox5.KeyPress += textBox5_KeyPress;
            // 
            // Formated_Number
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 99);
            Controls.Add(textBox5);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Formated_Number";
            Text = "Formated Number";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private TextBox textBox5;
    }
}