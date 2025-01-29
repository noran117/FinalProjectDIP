namespace FinalProject
{
    partial class FilteredImageForm
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
            panAndZoomPictureBox1 = new Emgu.CV.UI.PanAndZoomPictureBox();
            ((System.ComponentModel.ISupportInitialize)panAndZoomPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(605, 449);
            panel1.TabIndex = 0;
            // 
            // panAndZoomPictureBox1
            // 
            panAndZoomPictureBox1.Dock = DockStyle.Fill;
            panAndZoomPictureBox1.Location = new Point(0, 0);
            panAndZoomPictureBox1.Name = "panAndZoomPictureBox1";
            panAndZoomPictureBox1.Size = new Size(605, 449);
            panAndZoomPictureBox1.TabIndex = 1;
            panAndZoomPictureBox1.TabStop = false;
            // 
            // FilteredImageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 449);
            Controls.Add(panAndZoomPictureBox1);
            Controls.Add(panel1);
            Name = "FilteredImageForm";
            Text = "FilteredImageForm";
            ((System.ComponentModel.ISupportInitialize)panAndZoomPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Emgu.CV.UI.PanAndZoomPictureBox panAndZoomPictureBox1;
    }
}