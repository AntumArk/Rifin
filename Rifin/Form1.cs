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
using Rifin.Forms;

namespace Rifin
{
    public partial class MainWindow : Form
    {
        public List<string> TrainingObjects = new List<string>();
      
        public VideoCapture capture;
        private BackgroundWorker matchingWorker;
        public Mat Source;
        private System.Windows.Forms.Timer timer; //Used for reading data in the right time. 

        Window window = new Window("window",WindowMode.FreeRatio);
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

        private void matchingCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //    throw new NotImplementedException();
            var result = (Mat)e.Result;



            window.Image= result;
            window.ShowImage(result);

        }

        private void matchingWorker_progressChanged(object sender, ProgressChangedEventArgs e)
        {
          //  throw new NotImplementedException();
      
        }
      /*  private void btnSURF_Click(object sender, EventArgs e)
        {
            Mat template = Cv2.ImRead(txtTemplate.Text, LoadMode.GrayScale);
            Mat src = Cv2.ImRead(txtScene.Text, LoadMode.Color);
            Cv2.Resize(src, src, new OpenCvSharp.CPlusPlus.Size(1920, 1080));
            Mat scene = new Mat();
            Cv2.CvtColor(src, scene, ColorConversion.RgbToGray);

            //Cv2.Resize(scene, scene, new OpenCvSharp.CPlusPlus.Size(1920, 1080));

            SURF surf = new SURF(500, 4, 2, true, true);

            KeyPoint[] keypoints_template = { };
            KeyPoint[] keypoints_scene = { };

            MatOfFloat descriptor_template = new MatOfFloat();
            MatOfFloat descriptor_scene = new MatOfFloat();

            surf.Run(template, null, out keypoints_template, descriptor_template);
            surf.Run(scene, null, out keypoints_scene, descriptor_scene);

            Window showtempl = new Window("template", WindowMode.FreeRatio);
            Window showscene = new Window("scene", WindowMode.FreeRatio);

            //Cia tik svarbus taskai atvaizduojami
            Mat template_ = new Mat();
            Mat scene_ = new Mat();
            Cv2.DrawKeypoints(template, keypoints_template, template_);
            Cv2.DrawKeypoints(scene, keypoints_scene, scene_);

            BFMatcher matcher = new BFMatcher(NormType.L2, false);
            DMatch[] matches = matcher.Match(descriptor_template, descriptor_scene);

            //Draw matches
            Mat view = new Mat();
            Cv2.DrawMatches(template, keypoints_template, scene, keypoints_scene, matches, view);

            List<OpenCvSharp.CPlusPlus.Point> points = new List<OpenCvSharp.CPlusPlus.Point>();
            for (int i = 0; i < matches.Length; i++)
            {
                if (matches[i].Distance < 5)
                {
                    points.Add(keypoints_scene[matches[i].TrainIdx].Pt);
                }
            }
            Mat view2 = new Mat();
            scene.CopyTo(view2);

            foreach (OpenCvSharp.CPlusPlus.Point pp in points)
            {
                Cv2.Circle(src, pp, 5, Scalar.Blue, 3);
            }

            Rect box = Cv2.BoundingRect(points);
            Cv2.Rectangle(src, box, Scalar.Green, 5);
            //    MessageBox.Show(" matches: " + matches.LongLength.ToString());

            showtempl.Image = src;
            showscene.Image = view;
        }*/
        /// <summary>
        /// Background thread for finding good matches and drawing them on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindMatches(object sender, DoWorkEventArgs e)
        {   //Loads up a list of pictures and object name
            List<object> genericlist = e.Argument as List<object>;
            var src = (Mat)genericlist[0];
            var objName = (string)genericlist[1];

            //Creates temp matrix
            Mat imgMatches = new Mat();

            //Step one: 
            //Open folder of an object
            var workPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisualData", objName);
            Environment.CurrentDirectory = workPath;
            //Step two:
            //Load a list of items
            var imgFiles = Directory.GetFileSystemEntries("Images");
            var keypointFiles = Directory.GetFileSystemEntries("Keypoints");

            //Step 3:
            //Change source image color
            Cv2.CvtColor(src, src, ColorConversionCodes.RGB2GRAY);

            float progressTick = 100/(float)imgFiles.Length;

            float counter = 0;
            int z = 0;
            foreach (var imgFile in imgFiles)
            {
                //Load database picture from file
                Mat img_2 = Cv2.ImRead(imgFile, ImreadModes.GrayScale);

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
        /// Main event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
          
           
                GC.Collect();
                Mat Source = new Mat();
                     capture.Read(Source);
            // src = DetectFeatures(src);
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
                Main_PictureBox.Image = Source.ToBitmap();
            
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
        
        /// <summary>
        /// Start and launch control
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

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Image processing and Main_Picturebox updates
        /// </summary>
        private void mainT()
        {
          
              
             //   Main_PictureBox.Image = Source.ToBitmap();
            
           
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

      

    }
}
