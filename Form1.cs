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
using Face_Detection_in_forms.Properties;
using AForge.Imaging.Filters;

namespace Face_Detection_in_forms
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
            foreach (FilterInfo device in filter)
                cboDevice.Items.Add(device.Name);
            cboDevice.SelectedIndex = 0;
            device = new VideoCaptureDevice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            device = new VideoCaptureDevice(filter[cboDevice.SelectedIndex].MonikerString);
            device.NewFrame += Device_NewFrame;
            device.Start();
        }
        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            try
            {
                bitmap = (Bitmap)eventArgs.Frame.Clone();

                var filter = new Mirror(false, true);
                filter.ApplyInPlace(bitmap);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Image<Bgr, byte> grayimage = new Image<Bgr, byte>(bitmap);
            Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayimage, 1.2 , 1);
            Console.WriteLine(rectangles.Length);
            if(rectangles.Length>0)
            {
                Console.WriteLine(rectangles[0].X);
                Console.WriteLine(rectangles[0].Y);
                textBox1.Invoke(new Action(() => textBox1.Text = rectangles[0].X.ToString()));               
                textBox2.Invoke(new Action(() => textBox2.Text = rectangles[0].Y.ToString()));

                rects = rectangles;
            }
          
            foreach (Rectangle rectangle in rectangles)
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Pen pen = new Pen(Color.Green, 1))
                    { 
                        graphics.DrawRectangle(pen, rectangle); 
                    }                  
                }

            }
            pic.Image = bitmap;
 
        }       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (device.IsRunning)
                device.Stop();
        }
        private void pic_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
