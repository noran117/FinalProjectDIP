using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
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
    public partial class ImageAnalysis : Form
    {
        public Image FilteredImage { get; set; }
        public List<Mat> images = new List<Mat>();
        public ImageAnalysis()
        {
            InitializeComponent();
        }
        public ImageAnalysis(Mat img)
        {
            InitializeComponent();
            FilteredImage = img.ToBitmap();
            Filters(img);
        }
        void Filters(Mat img)
        {
            CvInvoke.CvtColor(img, img, ColorConversion.Bgr2Gray);

            Mat laplacian = new Mat();
            CvInvoke.Laplacian(img, laplacian, img.Depth);
            Mat absLaplacian = new Mat();
            CvInvoke.ConvertScaleAbs(laplacian, absLaplacian, 1, 0);
            panAndZoomPictureBox1.Image = absLaplacian.ToBitmap();
            images.Add(absLaplacian);

            Mat filtered_sobelX = new Mat(img.Rows, img.Cols, img.Depth, img.NumberOfChannels);
            CvInvoke.Sobel(
                src: img,
                dst: filtered_sobelX,
                ddepth: img.Depth,
                xorder: 1,
                yorder: 0);
            panAndZoomPictureBox2.Image = filtered_sobelX.ToBitmap();
            images.Add(filtered_sobelX);

            Mat filtered_sobelY = new Mat(img.Rows, img.Cols, img.Depth, img.NumberOfChannels);
            CvInvoke.Sobel(
                src: img,
                dst: filtered_sobelY,
                ddepth: img.Depth,
                xorder: 0,
                yorder: 1);
            panAndZoomPictureBox3.Image = filtered_sobelY.ToBitmap();
            images.Add(filtered_sobelY);

            Mat cannyEdges = new Mat();
            CvInvoke.Canny(img, cannyEdges, 50, 150);
            panAndZoomPictureBox4.Image = cannyEdges.ToBitmap();
            images.Add(cannyEdges);


        }
    }
}
