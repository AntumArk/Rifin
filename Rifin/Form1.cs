using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.XFeatures2D;
using Rifin.Forms;

namespace Rifin
{
    public partial class MainWindow : Form
    {
       public VideoCapture capture;
        public Thread videoStreamThread;
        public Thread mainThread;
        public Mat Source;

        public MainWindow()
        {
            InitializeComponent();
            Source = new Mat(new OpenCvSharp.Size(640, 480), MatType.CV_8U,Scalar.White);
            videoStreamThread = new Thread(videoStreamT);
            mainThread = new Thread(mainT);
            mainThread.Start();
        }
        /// <summary>
        /// Adds song to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSong_Button_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Launches training window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Training_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrainingForm n = new TrainingForm();
            n.ShowDialog();
        }
        

        private void StartSteam_Button_CheckedChanged(object sender, EventArgs e)
        {
            if (StartSteam_Button.Checked)
            {if (videoStreamThread.ThreadState != ThreadState.Suspended)
                    videoStreamThread.Start();
                else
                    videoStreamThread.Resume();
                StartSteam_Button.BackColor = Color.Red;
                StartSteam_Button.Text = "Stop Video";
            }
            else
            {
                videoStreamThread.Suspend();
                StartSteam_Button.BackColor = Color.Green;
                StartSteam_Button.Text = "Start Video";


            }

        }

        /// <summary>
        /// Reads video images
        /// </summary>
        private void videoStreamT()
        {
            capture = new VideoCapture(0);
            while(true)
            {
                GC.Collect();
                Mat src = new Mat();
                capture.Read(src);
                
                src.CopyTo(Source);
                src = DetectFeatures(src);
                    Main_PictureBox.Image = src.ToBitmap();
                
                
            }
        }
        /// <summary>
        /// Image processing and Main_Picturebox updates
        /// </summary>
        private void mainT()
        {
            while (true) {
              
             //   Main_PictureBox.Image = Source.ToBitmap();
            }
           
        }
        /// <summary>
        /// Live feature detector
        /// </summary>
        /// <param name="strem"></param>
        private Mat DetectFeatures(Mat strem)
        {
            ////-- Step 1: Detect the keypoints using SURF Detector, compute the descriptors
            int minHessian = 400;
            SURF detector = SURF.Create(minHessian);

           
            KeyPoint[] keypoints;
            Mat descriptors = new Mat();


            detector.DetectAndCompute(strem, new Mat(), out keypoints, descriptors);

            Mat imge = new Mat();

            strem.CopyTo(imge);
            for (int i = 0; i < keypoints.Length; i++)
            {
                Cv2.Circle(imge, (int)keypoints[i].Pt.X, (int)keypoints[i].Pt.Y, (int)keypoints[i].Size/2, Scalar.Red, 2);

            }

            return imge;
      
        }

        /// <summary>
        /// Proper way to close application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (videoStreamThread.ThreadState != ThreadState.Suspended)
                videoStreamThread.Abort();
            if (mainThread.ThreadState != ThreadState.Suspended)
                mainThread.Abort();
            if(capture!=null)
            capture.Release();
            Application.Exit();
        }
    }
}
