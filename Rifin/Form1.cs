using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.XFeatures2D;
using Rifin.Data;
using Rifin.Forms;

namespace Rifin
{
    public partial class MainWindow : Form
    {
        public List<string> TrainingObjects = new List<string>();//A list of part names
        public List<Part> Parts = new List<Part>(); //A list to hold information about a part. Its name and its descriptors.

        public VideoCapture capture;
        private BackgroundWorker matchingWorker;

        public Mat Source;  //Video frames
        private System.Windows.Forms.Timer timer; //Used for reading data in the right time. 

      //  Window window = new Window("window",WindowMode.FreeRatio);
        public MainWindow()
        {
            InitializeComponent();

            Source = new Mat(new OpenCvSharp.Size(640, 480), MatType.CV_8U,Scalar.White);
            addDescriptorControl1.Hide();
            capture = new VideoCapture(0);

            Environment.CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Loading already prepared objects
          var directories= Directory.EnumerateDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisualData")).ToList();
            foreach (var dir in directories)
            {
               TrainingObjects.Add( dir.Substring(dir.LastIndexOf("\\") + 1));

                Parts.Add(new Part { Name = dir.Substring(dir.LastIndexOf("\\") + 1) });
            }

            //Load data for each part
            foreach (var part in Parts)
            {
                part.Descriptors = new List<Mat>();
                part.Images = new List<Mat>();
                //Step one: 
                //Open folder of an object
                var workPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisualData", part.Name);
                Environment.CurrentDirectory = workPath;
                //Step two:
                //Load a list of items
                var imgFiles = Directory.GetFileSystemEntries("Images");
                var descFiles = Directory.GetFileSystemEntries("Descriptors");
                Debug.WriteLine("Loading descriptors", "Loading");
                //Load descriptors
                foreach (var descFile in descFiles)
                {

                    using (var fs = new FileStorage(descFile, FileStorage.Mode.Read))
                    {

                        Mat mat = fs[part.Name].ReadMat();
                        part.Descriptors.Add(mat);
                        using (var window = new Window(mat))
                        {
                            Cv2.WaitKey(0);
                        }
                    }
                 
                }
                Debug.WriteLine("Loading Images", "Loading");
                //Load images
                foreach (var imgFile in imgFiles)
                {
                    Mat mat = Cv2.ImRead(imgFile,ImreadModes.Color);
                    part.Images.Add(mat);
                   
                }
                Debug.WriteLine("Loading completed", "Loading");

            }


            //Updating text field with those objects
            richTextBox1.ResetText();
            if (TrainingObjects != null)
                foreach (var obj in TrainingObjects)
                    if (obj != null)
                        richTextBox1.AppendText(obj.ToString() + "\n");


            timer = new System.Windows.Forms.Timer();
            timer.Interval = (int)(1000 / 30);
            timer.Tick += new EventHandler(timer_Tick);


            //Initialize threads
            matchingWorker = new BackgroundWorker();
            matchingWorker.WorkerReportsProgress = true;
            matchingWorker.DoWork += new DoWorkEventHandler(FindMatches);
            matchingWorker.ProgressChanged += new ProgressChangedEventHandler(matchingWorker_progressChanged);
            matchingWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(matchingCompleted);
        }

        /// <summary>
        /// Updates image, when matching is completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matchingCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //    throw new NotImplementedException();
            var result = (Mat)e.Result; //Result is a new image with rectangles showing found objects.
            if (result != null)
            {
                Side_PictureBox.Image = result.ToBitmap();

              //  window.Image = result;
              //  window.ShowImage(result);
            }

        }

        private void matchingWorker_progressChanged(object sender, ProgressChangedEventArgs e)
        {
          //  throw new NotImplementedException();
      
        }
   
       
        /// <summary>
        /// Background thread for finding good matches and drawing them on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindMatches(object sender, DoWorkEventArgs e)
        {   //Loads up a list of pictures and object name
            List<object> genericlist = e.Argument as List<object>;
            var src = (Mat)genericlist[0];  //Frame from camera
            var objName = (string)genericlist[1];   //Object name (etc. Guitar, Bridge)

            //Creates temp matrix
            Mat imgMatches = new Mat();


            var imgFiles = "s";

            //Step 3:
            //Change source image color
            Cv2.CvtColor(src, src, ColorConversionCodes.RGB2GRAY);

            float progressTick = 100/(float)imgFiles.Length;

            float counter = 0;
            int z = 0;
            foreach (var imgFile in imgFiles)
            {
                //Load database picture from file
                Mat img_2 = Cv2.ImRead("", ImreadModes.GrayScale);

                // Step 1: Detect the keypoints using SURF Detector, compute the descriptors
                int minHessian = 400;
                SURF detector = SURF.Create(minHessian);


                KeyPoint[] keypoints_1, keypoints_2;
                Mat descriptors_1 = new Mat(), descriptors_2 = new Mat();

           
                //Detect and compute descriptors
                detector.DetectAndCompute(img_2, new Mat(), out keypoints_1, descriptors_1);
                detector.DetectAndCompute(src, new Mat(), out keypoints_2, descriptors_2);
               

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
               // Console.WriteLine("-- Max dist : %f", max_dist);
               // Console.WriteLine("-- Min dist : %f", min_dist);

                ////-- Draw only "good" matches (i.e. whose distance is less than 2*min_dist,
                ////-- or a small arbitrary value ( 0.02 ) in the event that min_dist is very
                ////-- small)  //-- PS.- radiusMatch can also be used here.
                List<DMatch> good_matches = new List<DMatch>();
                List<OpenCvSharp.Point> points = new List<OpenCvSharp.Point>();
                for (int i = 0; i < matches.Length; i++)
                {
                    if (matches[i].Distance <= Math.Max(2 * min_dist, 0.02))
                    {
                        good_matches.Add(matches[i]);
                        points.Add(keypoints_1[matches[i].TrainIdx].Pt);
                    }
                }

                ////-- Draw only "good" matches
                
              /*  Cv2.DrawMatches(src, keypoints_1, img_2, keypoints_2,
                    good_matches, imgMatches, Scalar.All(-1), Scalar.All(-1),
                    new List<byte>(), DrawMatchesFlags.NotDrawSinglePoints);*/
                

                Rect box = Cv2.BoundingRect(points);
                Cv2.Rectangle(imgMatches, box, Scalar.Green, 5);
                Cv2.PutText(imgMatches, objName, box.TopLeft,HersheyFonts.HersheyPlain,5,Scalar.Beige);
                //    MessageBox.Show(" matches: " + matches.LongLength.ToString());

                
                counter += progressTick;
                matchingWorker.ReportProgress((int)counter);
                Debug.WriteLine("Progress "+counter);
                z++;
                if (z == 1)
                    break;
            }
            e.Result = imgMatches;

        }

        /// <summary>
        /// Main event. Reads video image, shows it to the main window. Processes current frame in worker thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
                GC.Collect();
                Mat Source = new Mat();
            //Reads frame from camera
                     capture.Read(Source);
            // src = DetectFeatures(src);
            //For each obeject, try to find a match.
            foreach (var obj in TrainingObjects)
                {
                    if (obj != null)
                {
                    List<object> arguments = new List<object>
                    {
                        Source,
                        obj
                    };
                    if(!matchingWorker.IsBusy)
                    matchingWorker.RunWorkerAsync(arguments);

                    };
                }
            //Updates mainWindow image to camera frame.
                Main_PictureBox.Image = Source.ToBitmap();
            
        }

        /// <summary>
        /// Adds song to the list. NOT IMPLEMENTED
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
        
        /// <summary>
        /// Start and launch video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartSteam_Button_CheckedChanged(object sender, EventArgs e)
        {
            if (StartSteam_Button.Checked)
            {
                timer.Start();
                StartSteam_Button.BackColor = Color.Red;
                StartSteam_Button.Text = "Stop Video";
                
                

            }
            else
            {
                timer.Stop(); 

                StartSteam_Button.BackColor = Color.Green;
                StartSteam_Button.Text = "Start Video";
                
            }

        }
        
        /// <summary>
        /// Proper way to close application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
         
            if(capture!=null)
            capture.Release();
            Application.Exit();
        }
        /// <summary>
        /// Adds new object to the list when all of the descriptors, keypoints and images are saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addDescriptorControl1_VisibleChanged(object sender, EventArgs e)
        {
            TrainingObjects.Add(addDescriptorControl1.ObjectName);
            richTextBox1.ResetText();
            if(TrainingObjects!=null)
            foreach(var obj in TrainingObjects)
                    if (obj != null)
                        richTextBox1.AppendText(obj.ToString()+"\n");
        }
        /// <summary>
        /// Shows add new object window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddObjectButton_Click(object sender, EventArgs e)
        {
            addDescriptorControl1.Show();
        }

      

    }
}
