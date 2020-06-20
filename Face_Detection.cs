using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
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
        int i = 0;
        public Stopwatch watch { get; set; }    //Setting a stopwatch in case I  will need to add delay 
       

        private void Form1_Load(object sender, EventArgs e)
        {
            watch = Stopwatch.StartNew();
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);     
            serialPort1.Open();                                                 //Opens the port for serial communication
            writeToPort(new Point(280, 184));                                   //Default Position of the turret
            device = new VideoCaptureDevice(filter[0].MonikerString);  

            do
            {
               int data_rx = serialPort1.ReadChar();
                Console.WriteLine(data_rx);
                if (data_rx == 1)
                {
                    i = 1;
                }
            } while (i < 1);
            device.NewFrame += Device_NewFrame;
            device.Start();
                              
        }

        static readonly CascadeClassifier faceClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml"); //Face tranning model

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)     
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            try
            {
                var filter = new Mirror(false, true);                      //try catch argument if the video feed is inverted
                filter.ApplyInPlace(bitmap);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Image<Bgr, byte> image = new Image<Bgr, byte>(bitmap);
            Rectangle[] facerectangles = faceClassifier.DetectMultiScale(image, 1.2, 1);
            
            Console.WriteLine(facerectangles.Length);
            if (facerectangles.Length > 0)
            {
                int NewpointX = 472 - facerectangles[0].X;       //needs to be adjusted with your picturebox width
                int NewpointY = 300 - facerectangles[0].Y;       //needs to be adjusted with your picturebox height
                Console.WriteLine(facerectangles[0].X);
                Console.WriteLine(facerectangles[0].Y);
                textBox1.Invoke(new Action(() => textBox1.Text = facerectangles[0].X.ToString()));
                textBox2.Invoke(new Action(() => textBox2.Text = NewpointY.ToString()));

                
                Console.WriteLine("Width: {0}", pic.Size.Width);
                Console.WriteLine("Height: {0}", pic.Size.Height);

                writeToPort(new Point(NewpointX, NewpointY)); 

            }

            rects = facerectangles;
         
            foreach (Rectangle rectangle in facerectangles)                       //loop for drawing the rectangle on face
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

        private void writeToPort(Point coordinates)                            //Function to send face postision as serial data
        {
            if (watch.ElapsedMilliseconds > 15)
            {
                watch = Stopwatch.StartNew();
                int vidcam_angl = 120;                                       //Adjust the angle according to your webcam

                serialPort1.Write(String.Format("X{0}Y{1}", (180 - coordinates.X / (Size.Width / vidcam_angl)), (coordinates.Y / (Size.Height / vidcam_angl))));
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (device.IsRunning)
            {
                writeToPort(new Point(280, 184));                 //gets the turret into default position after closing the form
                Application.Exit();
                device.Stop();
            }
               
            serialPort1.DiscardOutBuffer();                     //put this in 'if' statement if you want to stop sending serial\
                                                                  //data when the form is closed.
        }
    }
}
    

