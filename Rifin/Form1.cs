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
using OpenCvSharp.Cuda;
namespace Rifin
{
    public partial class MainWindow : Form
    {

        public static string haarDataLocation;
        public static string hogDataLocation;

        public List<HogPart> HogParts = new List<HogPart>(); //A list to hold information about a part. Its name and its descriptors.
        public List<HaarPart> HaarParts = new List<HaarPart>();

        private List<HogPart> SelectedHogParts = new List<HogPart>(); //A list to hold information about a part. Its name and its descriptors.
        private List<HaarPart> SelectedHaarParts = new List<HaarPart>();

        public VideoCapture capture;

        public Mat Source;  //Video frames
        private System.Windows.Forms.Timer timer; //Used for reading data in the right time. 

      //  Window window = new Window("window",WindowMode.FreeRatio);
        public MainWindow()
        {
            InitializeComponent();
            InitializeModules();
            
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
            if (Source != null)
            {
                // Cv2.FastNlMeansDenoisingColored(Source,Source);
                //  Source = FilteredImage(Source);
                Cv2.Flip(Source, Source, FlipMode.Y);
                if (haar_Radio.Checked&&SelectedHaarParts.Count!=0)
                {
                    List<Rect[]> foundMatches = new List<Rect[]>();
                    foreach (var part in SelectedHaarParts)
                    {
                        foundMatches.Add(part.GetHaarDetections(Source));
                    }
                    int i = 0;
                    foreach (var match in foundMatches)
                    {
                        foreach (Rect rect in match)
                        {
                              Source.Rectangle(rect.TopLeft, rect.BottomRight, SelectedHaarParts[i].color, 3, LineTypes.Link8, 0);
                            Source.PutText(SelectedHaarParts[i].Name, new OpenCvSharp.Point(rect.Location.X + 5, rect.Location.Y + 20), HersheyFonts.HersheyPlain, 2, SelectedHaarParts[i].color,2, LineTypes.Link8);
                        }
                        i++;
                    }
                    // Cv2.AddWeighted(Source,255, rectMat,255,1, Source);
                    // rectMat.CopyTo(Source);
                   
                }
                else
                    if (hog_Radio.Checked && SelectedHogParts.Count != 0)
                {


                }
                try { Main_PictureBox.Image = Source.ToBitmap(); } catch { }
                    

                // if (!matchingWorker.IsBusy)
                //  matchingWorker.RunWorkerAsync(Source);
            }

            //Updates mainWindow image to camera frame.
        
               
            
        }
        //Paveiksliuko filtravimas naudojant matricas
        private Mat FilteredImage(Mat input)
        {
            Mat equalized = new Mat() ;
            Cv2.CvtColor(input, equalized, ColorConversionCodes.BGR2YCrCb);
            var channels = equalized.Split();
            Cv2.EqualizeHist(channels[0], channels[0]);
            Cv2.Merge(channels, equalized);
            Cv2.CvtColor(equalized, equalized, ColorConversionCodes.YCrCb2BGR);

            return equalized;
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
  
      

        private void Advanced_Button_Click(object sender, EventArgs e)
        {
         
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void haarAdd_Button_Click(object sender, EventArgs e)
        {
            addDescriptorControl1.SetType(0);
            addDescriptorControl1.Show();
        }

        private void hogRemove_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to delete these objects? " + System.Environment.NewLine, "Object deletion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var objects = hogObjects_ListBox.CheckedItems;
                try
                {
                    foreach (var item in objects)
                    {
                        var path = Path.Combine(hogDataLocation, (string)item);
                        Directory.Delete(path, true);
                        HogParts.Remove(HogParts.First(c => c.Name == (string)item));
                        hogObjects_ListBox.Items.Remove((string)item);
                    };
                }
                catch (Exception) { };


            }

        }

        private void hogAdd_Button_Click(object sender, EventArgs e)
        {
            addDescriptorControl1.SetType(1);
            addDescriptorControl1.Show();
           
        }


        private void InitializeModules()
        {
            //Step one
            //Load all of the trained objects
            //While loading check if it is actually there.
            CheckAndUpdateFolders();
            HaarParts = GetHaarParts(haarDataLocation);
            HogParts = GetHogParts(hogDataLocation);
            //TODO HOG part loading

           
            //Step two
            //Prepare video capture
            Source = new Mat(new OpenCvSharp.Size(640, 480), MatType.CV_8U, Scalar.White);
            capture = new VideoCapture(0);
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            //Step three hide components
            addDescriptorControl1.Hide();

        }
        private void CheckAndUpdateFolders()
        {
            var currentDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Environment.CurrentDirectory = currentDir;
            var directories = Directory.EnumerateDirectories(currentDir).ToList();
            //Checks if the data folder is created, and if it is not, creates it.
            if (!directories.Contains(Path.Combine(currentDir, "VisualData")))
            {
                Directory.CreateDirectory("VisualData");

            }
            //Loading already prepared objects
            Environment.CurrentDirectory = Path.Combine(currentDir, "VisualData");
            currentDir = Environment.CurrentDirectory;
            var visualDirectories = Directory.EnumerateDirectories(currentDir).ToList();
            if (!visualDirectories.Contains(Path.Combine(currentDir, "HaarData")))
            {
                Directory.CreateDirectory("HaarData");

            }
            haarDataLocation = Path.Combine(currentDir, "HaarData");
            if (!visualDirectories.Contains(Path.Combine(currentDir, "HogData")))
            {
                Directory.CreateDirectory("HogData");

            }
            hogDataLocation = Path.Combine(currentDir, "HogData");

        }

        private List<HaarPart>GetHaarParts(string location)
        {
            logBox.AppendText("Loading Haar parts from " + location + System.Environment.NewLine);
            var folders = Directory.EnumerateDirectories(location).ToList();
            var parts = new List<HaarPart>();
            foreach (var dir in folders)
            {
                logBox.AppendText("Loading Haar part from " + dir + System.Environment.NewLine);
                //Update object list
                haarObjects_ListBox.Items.Add(dir.Substring(dir.LastIndexOf("\\") + 1));
                var classifier= Directory.GetFileSystemEntries(dir);
                parts.Add(new HaarPart ( dir.Substring(dir.LastIndexOf("\\") + 1),classifier[0]));
                logBox.AppendText("Loaded Haar part " + dir.Substring(dir.LastIndexOf("\\") + 1)+ System.Environment.NewLine);
            }
            logBox.AppendText("Loading Haar parts completed. Num of parts: " + parts.Count+ System.Environment.NewLine);
            return parts;

            }
        private List<HogPart> GetHogParts(string location)
        {
            logBox.AppendText("Loading Hog parts from " + location + System.Environment.NewLine);
            var folders = Directory.EnumerateDirectories(location).ToList();
            var parts = new List<HogPart>();
            foreach (var dir in folders)
            {
                logBox.AppendText("Loading Hog part from " + dir + System.Environment.NewLine);
                //Update object list
                hogObjects_ListBox.Items.Add(dir.Substring(dir.LastIndexOf("\\") + 1));
                var classifier = Directory.GetFileSystemEntries(dir);
                parts.Add(new HogPart(dir.Substring(dir.LastIndexOf("\\") + 1), classifier[0]));
                logBox.AppendText("Loaded Hog part " + dir.Substring(dir.LastIndexOf("\\") + 1) + System.Environment.NewLine);
            }
            logBox.AppendText("Loading Hog parts completed. Num of parts: " + parts.Count + System.Environment.NewLine);
            return parts;

        }
        private void addDescriptorControl1_VisibleChanged(object sender, EventArgs e)
        {
            if(!addDescriptorControl1.Visible&&addDescriptorControl1.LoadingSuccessful)
                switch (addDescriptorControl1.ObjectType)
                {
                case 0:
                        HaarParts.Add(addDescriptorControl1.GetHaarPart());
                        logBox.AppendText("Loaded Haar part " + System.Environment.NewLine);
                        haarObjects_ListBox.Items.Add(addDescriptorControl1.GetHaarPart().Name);
                        addDescriptorControl1.LoadingSuccessful = false;
                        break;
                    case 1:
                        HogParts.Add(addDescriptorControl1.GetHogPart());
                        logBox.AppendText("Loaded Hog part " + System.Environment.NewLine);
                        hogObjects_ListBox.Items.Add(addDescriptorControl1.GetHogPart().Name);
                        addDescriptorControl1.LoadingSuccessful = false;
                        break;
                }
        }

        private void haarObjects_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedHaarParts.Clear();
            foreach (var part in HaarParts)
            {

            
            foreach (var item in haarObjects_ListBox.CheckedItems)
            {if(part.Name==(string)item)
                    SelectedHaarParts.Add(part);
                }
          
            }
        }

        private void hogObjects_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedHogParts.Clear();
            foreach (var part in HogParts)
            {


                foreach (var item in hogObjects_ListBox.CheckedItems)
                {
                    if (part.Name == (string)item)
                        SelectedHogParts.Add(part);
                }

            }
        }

        private void haarRemove_Button_Click(object sender, EventArgs e)
        {
           DialogResult dialogResult= MessageBox.Show("Do you really want to delete these objects? " + System.Environment.NewLine + haarObjects_ListBox.CheckedItems,"Object deletion", MessageBoxButtons.YesNo);
            if (dialogResult==DialogResult.Yes)
            {
                var objects = haarObjects_ListBox.CheckedItems;
                try
                {
                    foreach (var item in objects)
                    {
                        var path = Path.Combine(haarDataLocation, (string)item);
                        Directory.Delete(path, true);
                        HaarParts.Remove(HaarParts.First(c => c.Name == (string)item));
                        haarObjects_ListBox.Items.Remove((string)item);
                    };
                }
                catch (Exception) { };


            }
          

        }
    }
}
