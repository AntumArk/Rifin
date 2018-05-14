﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.XFeatures2D;
using System.IO;

namespace Rifin.Forms
{
    public partial class AddDescriptorControl : UserControl
    {
        public List<Mat> ObjectImages = new List<Mat>();
        public List<Mat> ObjectDescriptors = new List<Mat>();
        public List<KeyPoint[]> ObjectKeyPoints = new List<KeyPoint[]>();

        private List<string> fileNames = new List<string>();

        public string ObjectName { get; set; }
        private int keypointsCount { get; set; }

        public AddDescriptorControl()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Close add window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseControlButton_Click(object sender, EventArgs e)
        {
            Hide();
        }
        /// <summary>
        /// Opens file location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadResourcesButton_Click(object sender, EventArgs e)
        {
            if(ObjectName=="")
            { MessageBox.Show("Please enter the name first"); } else


            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Multiselect = true,
                    InitialDirectory = @"E:\Coding Workspace\TrainingData\Rifin",
                    Filter = "image files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisualData", ObjectName, "Images"));
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisualData", ObjectName, "Descriptors"));

                    int i = 0;
                    keypointsCount = 0;
                    var files = openFileDialog1.FileNames;
                    ResourcesProgressBar.Step = 1;
                    ResourcesProgressBar.Maximum = files.Length;

                    ResourcesProgressBar.Value = 0;
                    foreach (var file in files)
                    {
                        Mat img = Cv2.ImRead(file);
                        //  img.ConvertTo(img, MatType.CV_32FC3);
                        Cv2.Resize(img, img, new OpenCvSharp.Size(640, 480));
                        ObjectImages.Add(img);
                        var data = DetectFeatures(img);
                        var points =(KeyPoint[]) data[0];
                        var desc =(Mat) data[1];
                        ObjectKeyPoints.Add(points);
                        ObjectDescriptors.Add(desc);

                        keypointsCount += ObjectKeyPoints[i].Length;
                        fileNames.Add(i.ToString());
                      
                        img.SaveImage(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"VisualData",ObjectName, "Images", i + ".jpg"));
                        desc.SaveImage(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisualData", ObjectName, "Descriptors", i + ".jpg"));
                        i++;
                        ResourcesProgressBar.Value += ResourcesProgressBar.Step;
                    }
                    LoadedImagesLabel.Text = i.ToString();
                    FoundKeypointsLabel.Text = keypointsCount.ToString();
                    ;
                }
            }
        }
        /// <summary>
        /// Gets all features that describes your object
        /// </summary>
        private List<object> DetectFeatures(Mat item)
        {
            ////-- Step 1: Detect the keypoints using SURF Detector, compute the descriptors
            List<object> results = new List<object>();
            int minHessian = 400;
            SURF detector = SURF.Create(minHessian);

            Mat descriptors = new Mat();
            detector.DetectAndCompute(item, new Mat(), out KeyPoint[] keypoints, descriptors); //TODO what to do with descriptors?
            results.Add(keypoints);
            results.Add(descriptors);


            return results;
        }

        private void SaveNewObjectButton_Click(object sender, EventArgs e)
        {
            if (ObjectName != null && ObjectName != "")
            {

                for (int i = 0; i < fileNames.Count; i++)
                {
                    ResourcesProgressBar.Step = 1;
                    ResourcesProgressBar.Maximum = fileNames.Count;

                    ResourcesProgressBar.Value = 0;
                    Environment.CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    System.IO.Directory.CreateDirectory(Path.Combine("VisualData",ObjectName,"Keypoints"));

                    Environment.CurrentDirectory = Path.Combine("VisualData", ObjectName, "Keypoints");
                    var fileName ="Keypoints_" + fileNames[i] + ".yml";

                    FileStorage fs = new FileStorage(fileName, FileStorage.Mode.Write);
                    for (int j = 0; j < ObjectKeyPoints[i].Length; j++)
                    {
                        fs.Write(ObjectName, ObjectKeyPoints[i][j].ToString());
                       
                    }
                    fs.Release();
                     ResourcesProgressBar.Value += ResourcesProgressBar.Step;
                    
                }
                Hide();
            }
            else
                MessageBox.Show("Don't leave object name empty");

        }

        private void NewObjectTextBox_TextChanged(object sender, EventArgs e)
        {
            ObjectName = NewObjectTextBox.Text;
        }
    }
}
