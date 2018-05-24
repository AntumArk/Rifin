using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.XFeatures2D;
namespace Rifin.Data
{
   public class HogPart
    {
        public string Name { get; set; }
        public HOGDescriptor descriptor;

        public HogPart(string name,string descriptorLocation)
        {
            Name = name;
            descriptor = new HOGDescriptor(descriptorLocation);
        }
        public Mat GetHogDetections(Mat src)
        {
            if (descriptor != null)
            {
                //var stuff = descriptor.DetectMultiScaleROI(src);
               // Rect[] matches = classifier.DetectMultiScale(src, 1.1, 3, HaarDetectionType.FindBiggestObject, new OpenCvSharp.Size(100, 100), new OpenCvSharp.Size(640, 480));

             
            }
            return src;
        }
    }
}
