using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalProject
{
    public partial class ProcessAnImage : Form
    {
        public Mat originalImage = new Mat();
        public Mat processedImage = new Mat();
        Image<Bgr, byte>? logo;
        Rectangle cropRectangle;
        bool isMouseDragging = false;
        Point start;

        Stack<Mat> imageHistory = new Stack<Mat>();

        private bool isLogoApplied = false;
        List<Mat> image = new List<Mat>();

        ColorDialog colorDialog = new ColorDialog();
        Color selectedColor;


        public ProcessAnImage()
        {
            InitializeComponent();
            this.Text = "Image Processing";
            this.StartPosition = FormStartPosition.CenterScreen;

            label1.Text = Text = $"Project Image Processing";
            label1.ForeColor = Color.White;
            label1.Font = new System.Drawing.Font("Segoe UI", 15, FontStyle.Bold);
            label1.BackColor = Color.DarkBlue;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Width = panel2.Width;



            label2.Text = Text = "Welcom...";
            label2.ForeColor = Color.Black;
            label2.Font = new System.Drawing.Font("Segoe UI", 12, FontStyle.Regular);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                panAndZoomPictureBox1.Image = new Mat(filepath).ToBitmap();
                originalImage = BitmapExtension.ToMat((Bitmap)panAndZoomPictureBox1.Image);

                FileInfo fileInfo = new FileInfo(filepath);
                string metadata = $"File Size: {fileInfo.Length / 1024} KB\n" +
                   $"Created: {fileInfo.CreationTime}\n" +
                   $"Modified: {fileInfo.LastWriteTime}";

                label23.Text = Text = $"Width: {originalImage.Width}\nHeight: {originalImage.Height}\nFormat: {Path.GetExtension(filepath).TrimStart('.')} \nMetadata: {metadata}";
                label23.ForeColor = Color.Black;
                label23.Font = new System.Drawing.Font("Segoe UI", 12, FontStyle.Bold);

                processedImage = originalImage.Clone();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancel_groups();
            groupBox9.Visible = true;

        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;
            try
            {
                imageHistory.Push(processedImage.Clone());

                int width = int.Parse(textBox1.Text);
                int height = int.Parse(textBox2.Text);
                if (checkBox1.Checked)
                {
                    double aspectRatio = (double)originalImage.Width / originalImage.Height;
                    if (width > height * aspectRatio)
                        width = (int)(height * aspectRatio);
                    else
                        height = (int)(width / aspectRatio);
                }

                CvInvoke.Resize(processedImage, processedImage, new Size(width, height));

                panAndZoomPictureBox1.Image = processedImage.ToBitmap();

                /*
                FilteredImageForm filteredImageForm = new FilteredImageForm(processedImage);
                filteredImageForm.ShowDialog();

                // Retrieve the processed image if needed
                if (filteredImageForm.FilteredImage != null)
                {
                    processedImage = BitmapExtension.ToMat((Bitmap)filteredImageForm.FilteredImage);
                }
                */
                groupBox9.Visible = false;
            }
            catch
            {
                MessageBox.Show("Cannot resize the image..");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            new Histogram(originalImage).Show();

        }


        private void button8_Click(object sender, EventArgs e)
        {
            groupBox10.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cancel_groups();
            groupBox11.Visible = true;
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                imageHistory.Push(processedImage.Clone());

                int angle = (int)numericUpDown2.Value;
                angle %= 360;
                Mat outputImage = new Mat();
                switch (angle)
                {
                    case 90:
                    case -270:
                        CvInvoke.Rotate(processedImage, outputImage, RotateFlags.Rotate90Clockwise);
                        break;

                    case -90:
                    case 270:
                        CvInvoke.Rotate(processedImage, outputImage, RotateFlags.Rotate90CounterClockwise);
                        break;

                    case 180:
                    case -180:
                        CvInvoke.Rotate(processedImage, outputImage, RotateFlags.Rotate180);
                        break;

                    case 360:
                    case -360:
                    case 0:
                        outputImage = processedImage.Clone();
                        break;

                }
                panAndZoomPictureBox1.Image = outputImage.ToBitmap();
            }
            catch { }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            groupBox11.Visible = false;
            processedImage = BitmapExtension.ToMat((Bitmap)panAndZoomPictureBox1.Image);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cancel_groups();
            groupBox13.Visible = true;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                logo = new Image<Bgr, byte>(ofd.FileName);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                imageHistory.Push(processedImage.Clone());

                //Add text
                int x = Convert.ToInt32(textBox14.Text);
                int y = Convert.ToInt32(textBox12.Text);
                Mat imageMat = processedImage;
                string text = textBox13.Text;


                byte B = Convert.ToByte(textBox11.Text);
                byte G = Convert.ToByte(textBox10.Text);
                byte R = Convert.ToByte(textBox9.Text);

                MCvScalar color = new Bgr(B, G, R).MCvScalar;

                CvInvoke.PutText(
                    img: imageMat,
                    text: text,
                    org: new Point(x, y),
                    fontFace: FontFace.HersheyDuplex,
                    fontScale: 1.2,
                    color: color,
                    thickness: 1);

                panAndZoomPictureBox1.Image = processedImage.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select folder to save";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                string fullPath = Path.Combine(path, "Image" + ".png");

                int counter = 1;
                while (File.Exists(fullPath))
                {
                    // Modify the filename by appending a number
                    string newFileName = $"Image_ ({counter++})";
                    fullPath = Path.Combine(path, newFileName + ".png");
                }

                processedImage.Save(fullPath);

                if (image != null && image.Count != 0)
                {
                    try
                    {
                        for (int i = 0; i < image.Count; i++)
                        {
                            string imageName = Path.Combine(path, $"Image_{i + 1}.png");
                            image[i].ToBitmap().Save(imageName, ImageFormat.Png);
                        }
                        image.Clear();
                    }
                    catch
                    {
                        MessageBox.Show("Cannot save images!");
                    }
                }
                //we can save the other fitered images like in Sobel and the other filters
                MessageBox.Show("Image saved successfully!", "Save Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }





            /*
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                processedImage.ToBitmap().Save(saveFileDialog.FileName);
                
                if(image!=null && image.Count != 0)
                {
                    try
                    {
                        for(int i = 0; i < image.Count; i++)
                        {
                            image[i].ToBitmap().Save(saveFileDialog.FileName);
                            //image.RemoveAt(i);
                        }
                        image.Clear();
                    }
                    catch
                    {
                        MessageBox.Show("Cannot save images!");
                    }
                }
                //we can save the other fitered images like in Sobel and the other filters
                MessageBox.Show("Image saved successfully!", "Save Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }


        private void button9_Click(object sender, EventArgs e)
        {
            groupBox9.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cancel_groups();
            groupBox17.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (originalImage == null)
                    return;

                int x = int.Parse(textBox6.Text);
                int y = int.Parse(textBox5.Text);
                int width = int.Parse(textBox8.Text);
                int height = int.Parse(textBox7.Text);

                cropRectangle = new Rectangle(x, y, width, height);
                Mat Cropped = new Mat(processedImage, cropRectangle);

                new FilteredImageForm(Cropped).Show();

            }
            catch
            {
                MessageBox.Show("Enter valid values...");
            }
            groupBox17.Visible = false;
        }



        private void button7_Click(object sender, EventArgs e)
        {
            Cancel_groups();
            groupBox14.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            groupBox14.Visible = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            groupBox13.Visible = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            Filters filteres = new Filters(processedImage);
            filteres.ShowDialog();
            image = new List<Mat>(filteres.images.Count);
            for (int i = 0; i < filteres.images.Count; i++)
            {
                image.Add(filteres.images[i]);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (imageHistory.Count > 0)
            {
                // Restore the last saved state
                processedImage = imageHistory.Pop();
                panAndZoomPictureBox1.Image = processedImage.ToBitmap();
            }
            else
            {
                MessageBox.Show("No operations to undo.");
            }
            if (imageHistory.Count >= 10)
            {
                imageHistory.Clear(); // Clear history if it exceeds 10 items
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            ImageConversion_ filteredImageForm = new ImageConversion_(processedImage);
            filteredImageForm.ShowDialog();
            image = new List<Mat>(filteredImageForm.images.Count);
            for (int i = 0; i < filteredImageForm.images.Count; i++)
            {
                image.Add(filteredImageForm.images[i]);
            }

        }
        void Cancel_groups()
        {
            groupBox9.Visible = false;
            groupBox10.Visible = false;
            groupBox11.Visible = false;
            groupBox13.Visible = false;
            groupBox14.Visible = false;
            groupBox17.Visible = false;
            groupBox3.Visible = false;
        }


        private void button21_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            imageHistory.Push(processedImage.Clone());

            Mat bgr = processedImage;
            Mat ycbcr = new Mat();
            CvInvoke.CvtColor(bgr, bgr, ColorConversion.Bgra2Bgr);
            CvInvoke.CvtColor(bgr, ycbcr, ColorConversion.Bgr2YCrCb);

            VectorOfMat vm = new VectorOfMat();
            CvInvoke.Split(ycbcr, vm);

            Mat gray_he = new();
            CvInvoke.EqualizeHist(vm[0], gray_he);

            Mat color_he = new();
            VectorOfMat vm_he = new VectorOfMat(gray_he, vm[1], vm[2]);
            CvInvoke.Merge(vm_he, color_he);
            CvInvoke.CvtColor(color_he, color_he, ColorConversion.YCrCb2Bgr);

            FilteredImageForm filteredImageForm = new FilteredImageForm(color_he);
            filteredImageForm.ShowDialog();

            image.Add(color_he);

        }

        private void button28_Click(object sender, EventArgs e)
        {
            ImageAnalysis filteredImageForm = new ImageAnalysis(processedImage);
            filteredImageForm.ShowDialog();

            image = new List<Mat>(filteredImageForm.images.Count);
            for (int i = 0; i < filteredImageForm.images.Count; i++)
            {
                image.Add(filteredImageForm.images[i]);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            Mat mat = new Mat();
            CvInvoke.CvtColor(processedImage, mat, ColorConversion.Bgr2Gray);
            Mat img_exp = new Mat();
            RangeF min_max = mat.GetValueRange();
            double max = min_max.Max;
            double c = 255 / Math.Log(1 + max, Math.E);

            mat.ConvertTo(mat, DepthType.Cv32F);
            CvInvoke.Exp(mat / c, img_exp);
            img_exp -= 1;
            mat.ConvertTo(mat, DepthType.Cv8U);
            img_exp.ConvertTo(img_exp, DepthType.Cv8U);

            FilteredImageForm filteredImageForm = new FilteredImageForm(img_exp);
            filteredImageForm.ShowDialog();
            image.Add(img_exp);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            Mat img = new Mat();
            CvInvoke.CvtColor(processedImage, img, ColorConversion.Bgra2Gray);
            Mat img_log = new Mat();

            double c;
            RangeF min_max = img.GetValueRange();
            double max = min_max.Max;
            c = 255 / Math.Log(1 + max, Math.E);
            img.ConvertTo(img, DepthType.Cv32F);
            CvInvoke.Log(img + 1, img_log);
            img_log *= c;
            img.ConvertTo(img, DepthType.Cv8U);
            img_log.ConvertTo(img_log, DepthType.Cv8U);

            FilteredImageForm filteredImageForm = new FilteredImageForm(img_log);
            filteredImageForm.ShowDialog();
            image.Add(img_log);
        }

        private void panAndZoomPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (originalImage == null)
                    return;

                isMouseDragging = true;
                start = e.Location;
            }
            catch { }
        }

        private void panAndZoomPictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDragging)
            {
                cropRectangle = new Rectangle(
                    start.X,
                    start.Y,
                    e.X - start.X,
                    e.Y - start.Y);
                Refresh();
            }
        }

        private void panAndZoomPictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDragging)
            {
                isMouseDragging = false;

                Mat Cropped = new Mat(processedImage, cropRectangle);
                new FilteredImageForm(Cropped).Show();
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            imageHistory.Push(processedImage.Clone());

            Mat img = processedImage;
            CvInvoke.CvtColor(img, img, ColorConversion.Bgr2Gray);

            Mat img_power = new Mat();
            int c = 1 * 255;
            double g = 2.0;

            img.ConvertTo(img, DepthType.Cv32F);
            CvInvoke.Pow(img / 255.0, g, img_power);
            img_power *= c;
            img.ConvertTo(img, DepthType.Cv8U);
            img_power.ConvertTo(img_power, DepthType.Cv8U);

            FilteredImageForm filteredImageForm = new FilteredImageForm(img_power);
            filteredImageForm.ShowDialog();
            image.Add(img_power);

            /*
            double c = 1.0;
            double gamma = 2.0;

            Mat normalized = new Mat();
            img.ConvertTo(normalized, DepthType.Cv32F, c / 255.0);
            Mat gammaCorrected = new Mat();
            CvInvoke.Pow(normalized, gamma, gammaCorrected);
            gammaCorrected.ConvertTo(gammaCorrected, DepthType.Cv8U, 255.0);

            FilteredImageForm filteredImageForm = new FilteredImageForm(gammaCorrected);
            filteredImageForm.ShowDialog();
            */
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageHistory.Push(processedImage.Clone());

            Mat img = processedImage.Clone();

            if (img.IsEmpty)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            if (comboBox2.SelectedItem == null)
                return;

            string selectedOption = comboBox2.SelectedItem.ToString();

            switch (selectedOption)
            {
                case "Image":
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Filter = "Image Files|*.jpg;*.png;*.bmp",
                        Title = "Select Watermark Image"
                    };

                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                        return;

                    Mat watermark = CvInvoke.Imread(openFileDialog.FileName, ImreadModes.Color);

                    double scale = 0.2;
                    int width = (int)(watermark.Width * scale);
                    int height = (int)(watermark.Height * scale);
                    CvInvoke.Resize(watermark, watermark, new Size(width, height));

                    int xPos = img.Width - watermark.Width - 10;
                    int yPos = img.Height - watermark.Height - 10;

                    Rectangle roi = new Rectangle(xPos, yPos, watermark.Width, watermark.Height);
                    Mat roiMat = new Mat(img, roi);

                    if (xPos < 0 || yPos < 0 || roi.Width > img.Width || roi.Height > img.Height)
                    {
                        MessageBox.Show("Watermark is too large for the image.");
                        return;
                    }

                    CvInvoke.AddWeighted(roiMat, 0.7, watermark, 0.3, 0, roiMat);
                    roiMat.CopyTo(new Mat(img, roi));
                    break;

                case "Text":
                    string watermarkText = Interaction.InputBox(
                        "Enter watermark text:",
                        "Watermark Input",
                        "Default Watermark");

                    Color color;
                    using (ColorDialog colorDialog = new ColorDialog())
                    {
                        colorDialog.AllowFullOpen = true;
                        colorDialog.FullOpen = true;
                        color = Color.Black;

                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            color = colorDialog.Color;
                        }
                    }

                    CvInvoke.PutText(
                        img,
                        watermarkText,
                        new Point(img.Width / 10, img.Height - 50),
                        FontFace.HersheyComplexSmall,
                        1.2,
                        new MCvScalar(color.B, color.G, color.R),
                        2);
                    break;

                default:
                    MessageBox.Show("Invalid selection.");
                    return;
            }

            processedImage = img;
            panAndZoomPictureBox1.Image = processedImage.ToBitmap();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;
            try
            {

                // Add Logo
                if (logo == null)
                {
                    MessageBox.Show("Load the logo image first...");
                    return;
                }

                if (isLogoApplied)
                {
                    processedImage = imageHistory.Peek().Clone();       // Revert to the last saved state
                    isLogoApplied = false;
                }

                imageHistory.Push(processedImage.Clone());

                int imageWidth = processedImage.Width;
                int imageHeight = processedImage.Height;
                Mat secondImageMat = logo.Mat;
                Image<Bgr, byte> image = processedImage.ToImage<Bgr, byte>();

                Mat resizeLogo = new();
                CvInvoke.Resize(
                    secondImageMat,
                    resizeLogo,
                    new Size(0, 0),
                    fx: 0.1,
                    fy: 0.1,
                    interpolation: Emgu.CV.CvEnum.Inter.NearestExact);

                Mat logoGray = new();
                CvInvoke.CvtColor(resizeLogo, logoGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                Mat mask = new();
                CvInvoke.Threshold(logoGray, mask, 0, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
                Mat maskInv = new();
                CvInvoke.BitwiseNot(mask, maskInv);
                int logoWidth = resizeLogo.Width;
                int logoHeight = resizeLogo.Height;


                int x = 0, y = 0;
                if (radioButton1.Checked)
                {
                    x = y = 0;
                }
                else if (radioButton2.Checked)
                {
                    x = imageWidth - logoWidth;
                    y = 0;
                }
                else if (radioButton3.Checked)
                {
                    x = 0;
                    y = imageHeight - logoHeight;
                }
                else if (radioButton4.Checked)
                {
                    x = imageWidth - logoWidth;
                    y = imageHeight - logoHeight;
                }

                Rectangle roi = new Rectangle(x, y, logoWidth, logoHeight);
                Mat imageSub = new Mat(processedImage, roi);

                Mat forGround = new Mat();
                Mat backGround = new Mat();
                CvInvoke.BitwiseAnd(resizeLogo, resizeLogo, forGround, mask);
                CvInvoke.BitwiseAnd(imageSub, imageSub, backGround, maskInv);
                Mat full = forGround + backGround;

                image.ROI = roi;
                full.CopyTo(image);
                image.ROI = Rectangle.Empty;

                processedImage = image.Mat;

                FilteredImageForm filteredImageForm = new FilteredImageForm(processedImage);
                filteredImageForm.ShowDialog();

                if (filteredImageForm.FilteredImage != null)
                {
                    processedImage = BitmapExtension.ToMat((Bitmap)filteredImageForm.FilteredImage);
                }

                isLogoApplied = true;
                panAndZoomPictureBox1.Image = processedImage.ToBitmap();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Cancel_groups();
            groupBox3.Visible = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            imageHistory.Push(processedImage.Clone());

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;
                button20.BackColor = selectedColor;

                double alpha = (double)numericUpDown1.Value;
                processedImage = ApplyTint(processedImage, selectedColor, alpha);
                panAndZoomPictureBox1.Image = processedImage.ToBitmap();
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            imageHistory.Push(processedImage.Clone());

            double alpha = (double)numericUpDown1.Value;
            processedImage = ApplyTint(processedImage, selectedColor, alpha);

            panAndZoomPictureBox1.Image = processedImage.ToBitmap();
        }
        private Mat ApplyTint(Mat inputImage, Color tintColor, double alpha)
        {
            alpha = Math.Clamp(alpha, 0.0, 1.0);
            Image<Bgr, byte> tintedImage = inputImage.ToImage<Bgr, byte>();
            byte[,,] imageData = tintedImage.Data;

            byte tintB = (byte)(tintColor.B * alpha);
            byte tintG = (byte)(tintColor.G * alpha);
            byte tintR = (byte)(tintColor.R * alpha);

            for (int y = 0; y < tintedImage.Height; y++)
            {
                for (int x = 0; x < tintedImage.Width; x++)
                {
                    imageData[y, x, 0] = (byte)(imageData[y, x, 0] * (1 - alpha) + tintB);
                    imageData[y, x, 1] = (byte)(imageData[y, x, 1] * (1 - alpha) + tintG);
                    imageData[y, x, 2] = (byte)(imageData[y, x, 2] * (1 - alpha) + tintR);
                }
            }

            return tintedImage.Mat;
        }

        private void numericUpDown3_ValueChanged_1(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            imageHistory.Push(processedImage.Clone());
            CvInvoke.CvtColor(processedImage, processedImage, ColorConversion.Bgra2Bgr);

            double alpha = (double)numericUpDown4.Value; // Contrast 
            double beta = (double)numericUpDown3.Value; // Brightness 

            Mat adjustedImage = new Mat();
            processedImage.ConvertTo(adjustedImage, processedImage.Depth, alpha, beta);

            processedImage = adjustedImage;
            panAndZoomPictureBox1.Image = processedImage.ToBitmap();

        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            if (originalImage == null || originalImage.IsEmpty)
            {
                MessageBox.Show("No original image to reset to.");
                return;
            }

            processedImage = originalImage.Clone();
            panAndZoomPictureBox1.Image = processedImage.ToBitmap();
            imageHistory.Clear();
        }

        private HashSet<string> excludedButtons = new HashSet<string> { "button17", "button24" };
        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button btn )
            {
                if (!excludedButtons.Contains(btn.Name))
                {
                    btn.BackColor = Color.DarkBlue;
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.DarkBlue;
                }
            }
        }

        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button btn )
            {
                if (!excludedButtons.Contains(btn.Name))
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.DarkBlue;
                }
                else
                {
                    btn.BackColor = Color.DarkBlue;
                    btn.ForeColor = Color.White;
                }
            }
           
        }

        private void ProcessAnImage_Load(object sender, EventArgs e)
        {
            ApplyButtonHoverEffect(this);
        }
        private void ApplyButtonHoverEffect(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is System.Windows.Forms.Button btn )
                {
                    btn.MouseEnter += Button_MouseEnter;
                    btn.MouseLeave += Button_MouseLeave;
                }
                else if (ctrl.HasChildren) 
                {
                    ApplyButtonHoverEffect(ctrl);
                }
            }
        }
    }
}
