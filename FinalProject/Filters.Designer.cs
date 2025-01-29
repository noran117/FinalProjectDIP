namespace FinalProject
{
    partial class Filters
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
            panel1 = new Panel();
            label3 = new Label();
            button6 = new Button();
            button2 = new Button();
            label1 = new Label();
            button1 = new Button();
            panel2 = new Panel();
            label4 = new Label();
            button5 = new Button();
            button3 = new Button();
            label2 = new Label();
            button4 = new Button();
            panel3 = new Panel();
            panAndZoomPictureBox1 = new Emgu.CV.UI.PanAndZoomPictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panAndZoomPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(387, 449);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(61, 252);
            label3.Name = "label3";
            label3.Size = new Size(174, 31);
            label3.TabIndex = 4;
            label3.Text = "Color mapping";
            // 
            // button6
            // 
            button6.Location = new Point(83, 286);
            button6.Name = "button6";
            button6.Size = new Size(201, 54);
            button6.TabIndex = 3;
            button6.Text = "Cold Filter";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button2
            // 
            button2.Location = new Point(83, 130);
            button2.Name = "button2";
            button2.Size = new Size(201, 54);
            button2.TabIndex = 2;
            button2.Text = "Gaussian filter";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 36);
            label1.Name = "label1";
            label1.Size = new Size(134, 31);
            label1.TabIndex = 1;
            label1.Text = "Smoothing";
            // 
            // button1
            // 
            button1.Location = new Point(83, 70);
            button1.Name = "button1";
            button1.Size = new Size(201, 54);
            button1.TabIndex = 0;
            button1.Text = "Box filter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(button4);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(896, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(387, 449);
            panel2.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(68, 252);
            label4.Name = "label4";
            label4.Size = new Size(174, 31);
            label4.TabIndex = 7;
            label4.Text = "Color mapping";
            // 
            // button5
            // 
            button5.Location = new Point(82, 286);
            button5.Name = "button5";
            button5.Size = new Size(201, 54);
            button5.TabIndex = 6;
            button5.Text = "Warm Filter";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.Location = new Point(82, 146);
            button3.Name = "button3";
            button3.Size = new Size(201, 54);
            button3.TabIndex = 5;
            button3.Text = "Laplacian filter";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(68, 36);
            label2.Name = "label2";
            label2.Size = new Size(137, 31);
            label2.TabIndex = 4;
            label2.Text = "Sharpening";
            // 
            // button4
            // 
            button4.Location = new Point(82, 86);
            button4.Name = "button4";
            button4.Size = new Size(201, 54);
            button4.TabIndex = 3;
            button4.Text = "Sobel filter";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(panAndZoomPictureBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(387, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(509, 449);
            panel3.TabIndex = 2;
            // 
            // panAndZoomPictureBox1
            // 
            panAndZoomPictureBox1.Dock = DockStyle.Fill;
            panAndZoomPictureBox1.Location = new Point(0, 0);
            panAndZoomPictureBox1.Name = "panAndZoomPictureBox1";
            panAndZoomPictureBox1.Size = new Size(509, 449);
            panAndZoomPictureBox1.TabIndex = 0;
            panAndZoomPictureBox1.TabStop = false;
            // 
            // Filters
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1283, 449);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Filters";
            Text = "Filters";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panAndZoomPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button button2;
        private Label label1;
        private Button button1;
        private Button button3;
        private Label label2;
        private Button button4;
        private Label label3;
        private Button button6;
        private Label label4;
        private Button button5;
        private Emgu.CV.UI.PanAndZoomPictureBox panAndZoomPictureBox1;
    }
}