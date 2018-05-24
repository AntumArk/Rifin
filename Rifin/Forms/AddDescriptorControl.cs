using System;
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
using Rifin.Data;

namespace Rifin.Forms
{
    public partial class AddDescriptorControl : UserControl
    {
        
        
        public string ObjectName { get; set; }
        public string DescriptorPath { get; set; }
        public int ObjectType { get; set; }//0 - HAAR, 1 - HOG
        public bool LoadingSuccessful { get; set; }

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
        {// Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select a descriptor File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.  
                DescriptorPath = openFileDialog1.FileName;
            }
        }
       

        public void SaveNewObjectButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DescriptorPath)&& !string.IsNullOrEmpty(ObjectName))
            {
                switch (ObjectType)
                {
                    case 0:
                        var newharrObjectFolder = Path.Combine(MainWindow.haarDataLocation, ObjectName);
                        Directory.CreateDirectory(newharrObjectFolder);
                        var newhaarObject= Path.Combine(newharrObjectFolder, ObjectName+".xml");
                        File.Copy(DescriptorPath, newhaarObject);
                        LoadingSuccessful = true;
                        break;
                    case 1:
                        var newhogObjectFolder = Path.Combine(MainWindow.hogDataLocation, ObjectName);
                        Directory.CreateDirectory(newhogObjectFolder);
                        var newhogObject = Path.Combine(newhogObjectFolder, ObjectName + ".xml");
                        File.Copy(DescriptorPath, newhogObject);
                        LoadingSuccessful = true;
                        break;
                }
                label3.Text = "true";
               
                MessageBox.Show(ObjectName + " loaded!");

                Hide();
            }
            else
                MessageBox.Show("Don't leave object name empty or file not loaded");

        }
        public HaarPart GetHaarPart()
        {
            return new HaarPart(ObjectName, DescriptorPath);
        }
        public HogPart GetHogPart()
        {
            return new HogPart(ObjectName, DescriptorPath);
        }
        private void NewObjectTextBox_TextChanged(object sender, EventArgs e)
        {
            ObjectName = NewObjectTextBox.Text;
        }
        public void SetType(int type)
        {
            ObjectType = type;
            switch (type)
            {
                case 0:
                    type_Label.Text = "HAAR";
                    break;
                case 1:
                    type_Label.Text = "HOG";
                    break;
            }
        }
    }
}
