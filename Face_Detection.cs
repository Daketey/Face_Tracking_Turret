using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using AForge.Imaging.Filters;

namespace Face_Detection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FilterInfoCollection filter;
        VideoCaptureDevice device;
        Rectangle[] rects;
          

        private void Form1_Load(object sender, EventArgs e)
        {
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            device = new VideoCaptureDevice();
            serialPort1.Open();
        }

        private void button_Click(object sender, EventArgs e)
        {
            device = new VideoCaptureDevice(filter[0].MonikerString);
            device.NewFrame += Device_NewFrame;
            device.Start();
        }
        static readonly CascadeClassifier faceclassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        static readonly CascadeClassifier eyeclassifier = new CascadeClassifier("haarcascade_eye.xml");

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            try
            {
                var filter = new Mirror(false, true);
                filter.ApplyInPlace(bitmap);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Image<Bgr, byte> image = new Image<Bgr, byte>(bitmap);
            Rectangle[] rectangle1 = faceclassifier.DetectMultiScale(image, 1.2, 1);
            Rectangle[] rectangle2 = eyeclassifier.DetectMultiScale(image, 1.2, 10);

            rects = rectangle1;
            if (rects.Length > 0)
            {
                serialPort1.Write("Y");
            }
            else
            {
                serialPort1.Write("N");

            }
            foreach (Rectangle rectangle in rectangle1) 
            {
                using (Graphics graphics = Graphics.FromImage(bitmap)) 
                {
                    using (Pen pen = new Pen(Color.Green, 1)) 
                    {
                        graphics.DrawRectangle(pen, rectangle);
                    }                        
                }
                
            }
            foreach (Rectangle rectangle in rectangle2)
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Pen pen = new Pen(Color.Green, 1))
                    {
                        graphics.DrawRectangle(pen, rectangle);
                    }
                }

            }
            picbox.Image = bitmap;
            
        }
     
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (device.IsRunning)
                serialPort1.DiscardOutBuffer();
                    device.Stop();
            
        }
    }
}
