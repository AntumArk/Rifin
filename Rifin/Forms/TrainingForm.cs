using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp.ML;
using OpenCvSharp.Extensions;
using OpenCvSharp.XFeatures2D;

namespace Rifin.Forms
{
    public partial class TrainingForm : Form
    {

        public List<Mat> TrainingData;
        public List<Vec2f> Labels;
        

        public TrainingForm( )
        {
            InitializeComponent();
            TrainingData = new List<Mat>();
            Labels = new List<Vec2f>();
        }

        private void TrainingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow f = new MainWindow();
            f.Show();
        }
        /// <summary>
        /// Positive data file selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PosDataFolder_Button_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.InitialDirectory = @"E:\Coding Workspace\TrainingData\Rifin";
            openFileDialog1.Filter = "image files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int i = 0;
                var files= openFileDialog1.FileNames;
                progressBar1.Step = 1;
                progressBar1.Maximum = files.Length ;

                progressBar1.Value = 0;
                foreach (var file in files)
                { Mat img = Cv2.ImRead(file);
                    //  img.ConvertTo(img, MatType.CV_32FC3);
                    Cv2.Resize(img, img, new OpenCvSharp.Size(640, 480));
                    TrainingData.Add(img);
                    Labels.Add(new Vec2f(1,1));
                    i++ ;
                    progressBar1.Value += progressBar1.Step;
                }
                PosCount_Label.Text = "Positive count: " + i;
            }
        }
        /// <summary>
        /// Negative data file selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NegDataFolder_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.InitialDirectory = @"E:\Coding Workspace\TrainingData\Rifin";
            openFileDialog1.Filter = "image files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var files = openFileDialog1.FileNames;
                progressBar1.Step = 1;
                progressBar1.Maximum = files.Length;

                progressBar1.Value = 0;
                int i = 0;
                foreach (var file in files)
                {
                    Mat img = Cv2.ImRead(file);
                    //   img.ConvertTo(img, MatType.CV_32FC3);
                    Cv2.Resize(img, img, new OpenCvSharp.Size(640, 480));
                    TrainingData.Add(img);
                    Labels.Add(new Vec2f(-1, -1));
                    i++;
                    progressBar1.Value += progressBar1.Step;
                }
                NegCount_Label.Text = "Negative count: " + i;
            }
        }

        private  void Train_Button_ClickAsync(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to retrain ?? It will delete previous training data",
                                     "Confirm Retrain!!",
                                     MessageBoxButtons.YesNo);

           


            if (confirmResult == DialogResult.Yes)
            {
                DetectFeatures(TrainingData);
                TrainNewt();
                MessageBox.Show("Training completed Sensei");
            }
        }

        private  void TrainNewt()
        {
            // Train the SVM
            SVM svm = SVM.Create();
            svm.Type = SVM.Types.NuSvc;
            svm.KernelType = SVM.KernelTypes.Rbf;
            svm.TermCriteria = new TermCriteria(CriteriaType.MaxIter, 1000, 1e-6);
            svm.Degree = 5.0;
            svm.Gamma = 0.00001;
            svm.Coef0 = 3.0;
            svm.C = 1;
            svm.Nu = 0.5;
            svm.P = 0.1;

            Mat []trainData = TrainingData.ToArray();
            Mat labelData = new Mat(TrainingData.Count, 1, MatType.CV_32SC1);
            
          /*  for (int i = 0; i < trainingData.Count; i++)
            {
                trainData.Set(i, trainingData[i]);
                labelData.Set(i, labels[i]);

            }
              svm.Train(trainData, SampleTypes.RowSample, labelData);*/
            
            
          
        }
        /// <summary>
        /// Gets all features that describes your object
        /// </summary>
        private void DetectFeatures(List<Mat> trainingData)
        {
            ////-- Step 1: Detect the keypoints using SURF Detector, compute the descriptors
            int minHessian = 400;
            SURF detector = SURF.Create(minHessian);


            foreach (var item in trainingData)
            {
                KeyPoint[] keypoints;
                Mat descriptors = new Mat();

                FileStorage fs=new FileStorage("Keypoints.yml", FileStorage.Mode.Write);
                detector.DetectAndCompute(item, new Mat(), out keypoints, descriptors);
                int j = 0;
                Mat imge = new Mat();

                item.CopyTo(imge);
                progressBar1.Step=1;
                progressBar1.Maximum = keypoints.Length+1;
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;
                for (int i=0;i<keypoints.Length;i++)
                {
                    Cv2.Circle(imge,(int)keypoints[i].Pt.X, (int)keypoints[i].Pt.Y,5, Scalar.Red, 2);
                    
                fs.Write( "keypoints_1", keypoints[i].ToString());
                   // fs.Write("descriptors_1", descriptors.ToString());

                 
                    progressBar1.Value += progressBar1.Step;
            }
                fs.Release();
               // detector.Save(@"E:\Coding Workspace\TrainingData\Rifin\Keypoints\" + j + ".txt");
                    j++;
                //Window window = new Window(imge);
               // Cv2.WaitKey(0);
               // Window window1 = new Window(descriptors);
               // window.Dispose();
            }


           
           




        }
       








        }
    
}
