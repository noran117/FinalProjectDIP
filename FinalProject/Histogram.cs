using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
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
    public partial class Histogram : Form
    {
        Mat originalImage;
        public Histogram()
        {
            InitializeComponent();
        }
        public Histogram(Mat img)
        {
            InitializeComponent();
            originalImage = img;
            hist();
            convert();
        }
        void convert()
        {
            VectorOfMat vm = new VectorOfMat();
            CvInvoke.Split(originalImage, vm);
            Mat z = Mat.Zeros(originalImage.Rows, originalImage.Cols, originalImage.Depth, 1);

            Mat blue = new Mat();
            VectorOfMat blue_vm = new VectorOfMat(vm[0], z, z);
            CvInvoke.Merge(blue_vm, blue);

            Mat green = new Mat();
            VectorOfMat green_vm = new VectorOfMat(z, vm[1], z);
            CvInvoke.Merge(green_vm, green);

            Mat red = new Mat();
            VectorOfMat red_vm = new VectorOfMat(z, z, vm[2]);
            CvInvoke.Merge(red_vm, red);

            Mat gray = 0.299 * vm[2] + 0.587 * vm[1] + 0.114 * vm[0];

            imageBox1.Image = gray;
            imageBox3.Image = red;
            imageBox4.Image = green;
            imageBox5.Image = blue;

        }
        void hist()
        {
            //Gray Histogram
            Mat gray_mat = new();
            CvInvoke.CvtColor(originalImage, gray_mat, ColorConversion.Bgr2Gray);

            VectorOfMat setimages = new VectorOfMat(gray_mat);
            Mat hist = new Mat();

            CvInvoke.CalcHist(
                images: setimages,
                channels: new int[] { 0 },
                mask: null,
                hist: hist,
                histSize: new int[] { 256 },
                ranges: new float[] { 0, 255 },
                accumulate: false);


            MCvScalar color = new MCvScalar(128, 128, 128);
            Mat hist_image = GetHistImage(hist, color);

            imageBox2.Image = hist_image;

            //All Histogram
            Mat image_mat = originalImage;
            VectorOfMat BGR = new VectorOfMat();
            CvInvoke.Split(image_mat, BGR);

            Mat hist2 = new();
            Mat? hist_image2 = null;
            MCvScalar[] color2 = new MCvScalar[] { new MCvScalar(255, 0, 0), new MCvScalar(0, 255, 0), new MCvScalar(0, 0, 255) };

            for (int i = 0; i < image_mat.NumberOfChannels; i++)
            {
                CvInvoke.CalcHist(
                    images: BGR,
                    channels: new int[] { i },
                    mask: null,
                    hist: hist2,
                    histSize: new int[] { 256 },
                    ranges: new float[] { 0, 255 },
                    accumulate: false);

                hist_image2 = GetHistImage(hist2, color2[i], hist_image2);
            }
            histogramBox1.Image = hist_image2;

            //R Histogram
            Mat Rhist = new Mat();
            CvInvoke.CalcHist(
                images: BGR,
                channels: new int[] { 2 },
                mask: null,
                hist: Rhist,
                histSize: new int[] { 256 },
                ranges: new float[] { 0, 255 },
                accumulate: false);

            MCvScalar colorR = new MCvScalar(0, 0, 255);
            Mat Rhist_image = GetHistImage(Rhist, colorR);
            histogramBox2.Image = Rhist_image;

            //G Histogram
            Mat Ghist = new Mat();

            CvInvoke.CalcHist(
                images: BGR,
                channels: new int[] { 1 },
                mask: null,
                hist: Ghist,
                histSize: new int[] { 256 },
                ranges: new float[] { 0, 255 },
                accumulate: false);

            MCvScalar colorG = new MCvScalar(0, 255, 0);
            Mat Ghist_image = GetHistImage(Ghist, colorG);
            histogramBox3.Image = Ghist_image;

            //B Histogram
            Mat Bhist = new Mat();

            CvInvoke.CalcHist(
                images: BGR,
                channels: new int[] { 0 },
                mask: null,
                hist: Bhist,
                histSize: new int[] { 256 },
                ranges: new float[] { 0, 255 },
                accumulate: false);

            MCvScalar colorB = new MCvScalar(255, 0, 0);
            Mat Bhist_image = GetHistImage(Bhist, colorB);
            histogramBox4.Image = Bhist_image;

        }
        private static Mat GetHistImage(Mat hist, MCvScalar color, Mat? hist_image = null)
        {
            CvInvoke.Normalize(hist, hist, 0, 230, NormType.MinMax);

            hist.ConvertTo(hist, DepthType.Cv32S);

            if (hist_image == null)
                hist_image = new Image<Bgr, byte>(256, 230, new Bgr(255, 255, 255)).Mat;

            Point[] points = new Point[256];
            for (int i = 0; i < points.Length; i++)
                points[i] = new Point(i, 230 - (int)(hist.ToImage<Gray, byte>().Data[i, 0, 0]));

            CvInvoke.Polylines(
                img: hist_image,
                pts: points,
                isClosed: false,
                color: color);

            return hist_image;
        }
    }
}
