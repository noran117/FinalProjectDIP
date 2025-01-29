using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class FilteredImageForm : Form
    {
        public Image FilteredImage { get; set; }  

        public FilteredImageForm()
        {
            InitializeComponent();
        }
        public FilteredImageForm(Mat img)
        {
            InitializeComponent();
            FilteredImage = img.ToBitmap();
            panAndZoomPictureBox1.Image = FilteredImage;
        }
    }
}
