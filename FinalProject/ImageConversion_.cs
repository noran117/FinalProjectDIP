using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
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
    public partial class ImageConversion_ : Form
    {
        public Image FilteredImage { get; set; }
        public List<Mat> images = new List<Mat>();

        public ImageConversion_()
        {
            InitializeComponent();
        }
        public ImageConversion_(Mat img)
        {
            InitializeComponent();
            FilteredImage = img.ToBitmap();
            convert(img);
        }
        void convert(Mat img)
        {
            Mat gray = new Mat();
            CvInvoke.CvtColor(img, gray, ColorConversion.Bgr2Gray);
            panAndZoomPictureBox1.Image = gray.ToBitmap();
            images.Add(gray);

            Mat hsv = new Mat();
            CvInvoke.CvtColor(img, hsv, ColorConversion.Bgr2Hsv);
            panAndZoomPictureBox2.Image = hsv.ToBitmap();
            images.Add(hsv);

            Mat lab = new Mat();
            CvInvoke.CvtColor(img, lab, ColorConversion.Bgr2Lab);
            panAndZoomPictureBox3.Image = lab.ToBitmap();
            images.Add(lab);


        }
    }
}
