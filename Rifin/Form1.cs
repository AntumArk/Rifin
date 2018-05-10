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
        public List<string> TrainingObjects = new List<string>();
      
        public VideoCapture capture;
        public Thread videoStreamThread;
        public Thread mainThread;
        public Mat Source;

        public MainWindow()
        {
            InitializeComponent();
            Source = new Mat(new OpenCvSharp.Size(640, 480), MatType.CV_8U,Scalar.White);
            addDescriptorControl1.Hide();

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
           // this.Hide();
            TrainingForm n = new TrainingForm(this);
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
      
        private DMatch GetGoodMatches(Mat source,string objectName)
        {

            Mat img_1 = Cv2.ImRead("../../Images/icons.png", ImreadModes.GrayScale);
            Mat img_2 = Cv2.ImRead("../../Images/subIcons.png", ImreadModes.GrayScale);

            // Step 1: Detect the keypoints using SURF Detector, compute the descriptors
            int minHessian = 400;
           SURF detector = SURF.Create(minHessian);

            KeyPoint[] keypoints_1, keypoints_2;
            Mat descriptors_1 = new Mat(), descriptors_2 = new Mat();

            detector.DetectAndCompute(img_1, new Mat(), out keypoints_1, descriptors_1);
            detector.DetectAndCompute(img_2, new Mat(), out keypoints_2, descriptors_2);

            ////-- Step 2: Matching descriptor vectors using FLANN matcher
            FlannBasedMatcher matcher = new FlannBasedMatcher();
            DMatch[] matches;

            matches = matcher.Match(descriptors_1, descriptors_2);
            double max_dist = 0; double min_dist = 100;

            ////-- Quick calculation of max and min distances between keypoints
           for (int i = 0; i < descriptors_1.Rows; i++)
            {
                double dist = matches[i].Distance;
                if (dist < min_dist) min_dist = dist;
               if (dist > max_dist) max_dist = dist;
            }
            Console.WriteLine("-- Max dist : %f", max_dist);
            Console.WriteLine("-- Min dist : %f", min_dist);

            ////-- Draw only "good" matches (i.e. whose distance is less than 2*min_dist,
            ////-- or a small arbitrary value ( 0.02 ) in the event that min_dist is very
            ////-- small)  //-- PS.- radiusMatch can also be used here.
            List<DMatch> good_matches = new List<DMatch>();
            for (int i = 0; i < descriptors_1.Rows; i++)
            {
               if (matches[i].Distance <= Math.Max(2 * min_dist, 0.02))
               {
                   good_matches.Add(matches[i]);
               }
            }

            ////-- Draw only "good" matches
            Mat img_matches = new Mat();
            Cv2.DrawMatches(img_1, keypoints_1, img_2, keypoints_2,
                good_matches, img_matches, Scalar.All(-1), Scalar.All(-1),
                new List<byte>(), DrawMatchesFlags.NotDrawSinglePoints);

            ////-- Show detected matches  imshow( "Good Matches", img_matches );
            for (int i = 0; i < (int)good_matches.Count; i++)
            {
                Console.WriteLine("-- Good Match [%d] Keypoint 1: %d  -- Keypoint 2: %d", i,
                    good_matches[i].QueryIdx, good_matches[i].TrainIdx);
            }

            Cv2.WaitKey(0);


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

        private void addDescriptorControl1_VisibleChanged(object sender, EventArgs e)
        {
            TrainingObjects.Add(addDescriptorControl1.ObjectName);
            richTextBox1.ResetText();
            if(TrainingObjects!=null)
            foreach(var obj in TrainingObjects)
                    if (obj != null)
                        richTextBox1.AppendText(obj.ToString()+"\n");
        }

        private void AddObjectButton_Click(object sender, EventArgs e)
        {
            addDescriptorControl1.Show();
        }

        //// Token from C++ example:
        //// http://docs.opencv.org/3.1.0/d5/d6f/tutorial_feature_flann_matcher.html
        //// As of the writing of this routine,
        //// SIFT and SURF is a non-free code and is moved to the
        //// contrib repository and then link to the xfeatures2d library.

        //// So, you will get runtime error:
        //// Unable to find an entry point named 'xfeatures2d_SURF_create'
        //// in DLL 'OpenCvSharpExtern'.

        //// See these 2 links for an method on how to install the contrib library,
        //// it's a bit trick but do-able:
        //// https://github.com/shimat/opencvsharp/issues/146
        //// https://github.com/shimat/opencvsharp/issues/180


        //Mat img_1 = Cv2.ImRead("../../Images/icons.png", ImreadModes.GrayScale);
        //Mat img_2 = Cv2.ImRead("../../Images/subIcons.png", ImreadModes.GrayScale);

        ////-- Step 1: Detect the keypoints using SURF Detector, compute the descriptors
        //int minHessian = 400;
        //SURF detector = SURF.Create(minHessian);

        //KeyPoint[] keypoints_1, keypoints_2;
        //Mat descriptors_1 = new Mat(), descriptors_2 = new Mat();

        //detector.DetectAndCompute(img_1, new Mat(), out keypoints_1, descriptors_1);
        //detector.DetectAndCompute(img_2, new Mat(), out keypoints_2, descriptors_2);

        ////-- Step 2: Matching descriptor vectors using FLANN matcher
        //FlannBasedMatcher matcher = new FlannBasedMatcher();
        //DMatch[] matches;

        //matches = matcher.Match(descriptors_1, descriptors_2);
        //double max_dist = 0; double min_dist = 100;

        ////-- Quick calculation of max and min distances between keypoints
        //for (int i = 0; i < descriptors_1.Rows; i++)
        //{
        //    double dist = matches[i].Distance;
        //    if (dist < min_dist) min_dist = dist;
        //    if (dist > max_dist) max_dist = dist;
        //}
        //Console.WriteLine("-- Max dist : %f", max_dist);
        //Console.WriteLine("-- Min dist : %f", min_dist);

        ////-- Draw only "good" matches (i.e. whose distance is less than 2*min_dist,
        ////-- or a small arbitrary value ( 0.02 ) in the event that min_dist is very
        ////-- small)  //-- PS.- radiusMatch can also be used here.
        //List<DMatch> good_matches = new List<DMatch>();
        //for (int i = 0; i < descriptors_1.Rows; i++)
        //{
        //    if (matches[i].Distance <= Math.Max(2 * min_dist, 0.02))
        //    {
        //        good_matches.Add(matches[i]);
        //    }
        //}

        ////-- Draw only "good" matches
        //Mat img_matches = new Mat();
        //Cv2.DrawMatches(img_1, keypoints_1, img_2, keypoints_2,
        //    good_matches, img_matches, Scalar.All(-1), Scalar.All(-1),
        //    new List<byte>(), DrawMatchesFlags.NotDrawSinglePoints);

        ////-- Show detected matches  imshow( "Good Matches", img_matches );
        //for (int i = 0; i < (int)good_matches.Count; i++)
        //{
        //    Console.WriteLine("-- Good Match [%d] Keypoint 1: %d  -- Keypoint 2: %d", i,
        //        good_matches[i].QueryIdx, good_matches[i].TrainIdx);
        //}

        //Cv2.WaitKey(0);

    }
}
