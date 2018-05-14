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
   public class Part
    {
        public string Name { get; set; }
        public List<Mat> Descriptors { get; set; }
        public List<Mat> Images { get; set; }
       
    }
}
