using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
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
    public partial class Filters : Form
    {
        Matrix<byte> increase_lut = generate_gray_level_lut(new double[] { 0, 64, 128, 192, 255 }, new double[] { 0, 80, 160, 220, 255 });
        Matrix<byte> decrease_lut = generate_gray_level_lut(new double[] { 0, 64, 128, 192, 255 }, new double[] { 0, 50, 100, 150, 255 });
        public Image FilteredImage { get; set; }
        public List<Mat> images = new List<Mat>(); 
        public Filters()
        {
            InitializeComponent();
        }
        public Filters(Mat img)
        {
            InitializeComponent();
            FilteredImage = img.ToBitmap();
            panAndZoomPictureBox1.Image = FilteredImage;         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mat image = BitmapExtension.ToMat((Bitmap)FilteredImage);
            CvInvoke.CvtColor(image, image, ColorConversion.Bgra2Bgr);          
            Mat filteredLowpass = new Mat(image.Rows, image.Cols, image.Depth, image.NumberOfChannels);
            CvInvoke.BoxFilter(
            src: image,
            dst: filteredLowpass,
            ddepth: image.Depth,             
            ksize: new Size(3, 3),           
            anchor: new Point(-1, -1)        
            );

            panAndZoomPictureBox1.Image = filteredLowpass.ToBitmap();
            images.Add(filteredLowpass);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mat image = BitmapExtension.ToMat((Bitmap)FilteredImage);
            CvInvoke.CvtColor(image, image, ColorConversion.Bgra2Bgr);
            Mat filtered_gaussian = new Mat(image.Rows, image.Cols, image.Depth, image.NumberOfChannels);

            //Mat kernel = CvInvoke.GetGaussianKernel(7, 1.5);           
            //CvInvoke.Filter2D(
            //    src: image,
            //    dst: filtered_gaussian,
            //    kernel: kernel,
            //    anchor: new Point(-1, -1)
            //    );

            CvInvoke.GaussianBlur(
                src: image,
                dst: filtered_gaussian,
                ksize: new Size(7, 7),
                sigmaX: 1);
            panAndZoomPictureBox1.Image = filtered_gaussian.ToBitmap();
            images.Add(filtered_gaussian);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mat image = BitmapExtension.ToMat((Bitmap)FilteredImage);
            CvInvoke.CvtColor(image, image, ColorConversion.Bgra2Bgr);

            Mat filtered_sobel = new Mat(image.Rows, image.Cols, image.Depth, image.NumberOfChannels);

            CvInvoke.Sobel(
                src: image,
                dst: filtered_sobel,
                ddepth: image.Depth,
                xorder: 1,
                yorder: 1);
            panAndZoomPictureBox1.Image = filtered_sobel.ToBitmap();
            images.Add(filtered_sobel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mat image = BitmapExtension.ToMat((Bitmap)FilteredImage);
            CvInvoke.CvtColor(image, image, ColorConversion.Bgra2Bgr);

            Mat filtered_laplacian = new Mat(image.Rows, image.Cols, image.Depth, image.NumberOfChannels);

            CvInvoke.Laplacian(
                src: image,
                dst: filtered_laplacian,
                ddepth: image.Depth);
            panAndZoomPictureBox1.Image = filtered_laplacian.ToBitmap();
            images.Add( filtered_laplacian);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Mat image = BitmapExtension.ToMat((Bitmap)FilteredImage);
            CvInvoke.CvtColor(image, image, ColorConversion.Bgra2Bgr);

            //split
            VectorOfMat vm = new VectorOfMat();
            CvInvoke.Split(image, vm);

            //1- cold
            //change color map
            Mat new_b = new Mat();
            CvInvoke.LUT(vm[0], increase_lut, new_b);
            Mat new_g = vm[1];
            Mat new_r = new Mat();
            CvInvoke.LUT(vm[2], decrease_lut, new_r);

            //merge
            VectorOfMat new_vm = new VectorOfMat(new_b, new_g, new_r);
            Mat cold_image = new Mat();
            CvInvoke.Merge(new_vm, cold_image);

            panAndZoomPictureBox1.Image = cold_image.ToBitmap();
            images.Add(cold_image);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Mat image = BitmapExtension.ToMat((Bitmap)FilteredImage);
            CvInvoke.CvtColor(image, image, ColorConversion.Bgra2Bgr);

            //split
            VectorOfMat vm = new VectorOfMat();
            CvInvoke.Split(image, vm);

            //2- warm
            //change color map
            Mat new_b = new Mat();
            CvInvoke.LUT(vm[0], decrease_lut, new_b);
            Mat new_g = vm[1];
            Mat new_r = new Mat();
            CvInvoke.LUT(vm[2], increase_lut, new_r);

            //merge
            VectorOfMat new_vm = new VectorOfMat(new_b, new_g, new_r);
            Mat warm_image = new Mat();
            CvInvoke.Merge(new_vm, warm_image);

            panAndZoomPictureBox1.Image = warm_image.ToBitmap();
            images.Add(warm_image);
        }
        private static Matrix<byte> generate_gray_level_lut(double[] current, double[] target)
        {
            byte[] lut = new byte[256];

            if (current.Length != target.Length)
                throw new ArgumentException("inputs should be of the same size");

            double[,] equations_coefficient = get_equations_coefficient(current, target);

            for (int i = 0; i < lut.Length; i++)
            {
                int index = 0;
                for (int j = 0; j < current.Length - 2; j++)
                    if (i >= current[j] && i <= current[j + 1])
                    {
                        index = j;
                        break;
                    }
                //y=mx+b ===> temp = m*i+b
                double temp = equations_coefficient[index, 0] * i + equations_coefficient[index, 1];

                if (temp < 0)
                    temp = 0;
                if (temp > 255)
                    temp = 255;
                lut[i] = (byte)temp;
            }



            return new Matrix<byte>(lut);
        }
        private static double[,] get_equations_coefficient(double[] current, double[] target)
        {
            double[,] equations_coefficient = new double[current.Length - 1, 2];

            for (int i = 0; i < current.Length - 1; i++)
            {
                equations_coefficient[i, 0] = (target[i + 1] - target[i]) / (current[i + 1] - current[i]);
                equations_coefficient[i, 1] = target[i + 1] - equations_coefficient[i, 0] * current[i + 1];
            }

            return equations_coefficient;
        }
    }
}
