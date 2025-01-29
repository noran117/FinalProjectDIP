namespace FinalProject
{
    partial class ImageConversion_
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
            groupBox1 = new GroupBox();
            panAndZoomPictureBox1 = new Emgu.CV.UI.PanAndZoomPictureBox();
            groupBox2 = new GroupBox();
            panAndZoomPictureBox2 = new Emgu.CV.UI.PanAndZoomPictureBox();
            groupBox3 = new GroupBox();
            panAndZoomPictureBox3 = new Emgu.CV.UI.PanAndZoomPictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panAndZoomPictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panAndZoomPictureBox2).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panAndZoomPictureBox3).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panAndZoomPictureBox1);
            groupBox1.Location = new Point(12, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(319, 280);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "GrayScale";
            // 
            // panAndZoomPictureBox1
            // 
            panAndZoomPictureBox1.Dock = DockStyle.Fill;
            panAndZoomPictureBox1.Location = new Point(3, 23);
            panAndZoomPictureBox1.Name = "panAndZoomPictureBox1";
            panAndZoomPictureBox1.Size = new Size(313, 254);
            panAndZoomPictureBox1.TabIndex = 0;
            panAndZoomPictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panAndZoomPictureBox2);
            groupBox2.Location = new Point(337, 48);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(319, 280);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "HSV";
            // 
            // panAndZoomPictureBox2
            // 
            panAndZoomPictureBox2.Dock = DockStyle.Fill;
            panAndZoomPictureBox2.Location = new Point(3, 23);
            panAndZoomPictureBox2.Name = "panAndZoomPictureBox2";
            panAndZoomPictureBox2.Size = new Size(313, 254);
            panAndZoomPictureBox2.TabIndex = 0;
            panAndZoomPictureBox2.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(panAndZoomPictureBox3);
            groupBox3.Location = new Point(662, 48);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(319, 280);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "LAB";
            // 
            // panAndZoomPictureBox3
            // 
            panAndZoomPictureBox3.Dock = DockStyle.Fill;
            panAndZoomPictureBox3.Location = new Point(3, 23);
            panAndZoomPictureBox3.Name = "panAndZoomPictureBox3";
            panAndZoomPictureBox3.Size = new Size(313, 254);
            panAndZoomPictureBox3.TabIndex = 0;
            panAndZoomPictureBox3.TabStop = false;
            // 
            // ImageConversion_
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 370);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ImageConversion_";
            Text = "ImageConversion_";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panAndZoomPictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panAndZoomPictureBox2).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panAndZoomPictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Emgu.CV.UI.PanAndZoomPictureBox panAndZoomPictureBox1;
        private GroupBox groupBox2;
        private Emgu.CV.UI.PanAndZoomPictureBox panAndZoomPictureBox2;
        private GroupBox groupBox3;
        private Emgu.CV.UI.PanAndZoomPictureBox panAndZoomPictureBox3;
    }
}