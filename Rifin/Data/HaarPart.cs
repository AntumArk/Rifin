using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifin.Data
{
   public class HaarPart

    {
        public string Name { get;  set; }
        public CascadeClassifier classifier;
        public HaarPart(string name, string classifierLocation)
        {
            Name = name;
            classifier = new CascadeClassifier(classifierLocation);
        }
        public Mat GetHaarDetections(Mat src)
        {
            if (classifier!=null)
            {
                Rect[] matches = classifier.DetectMultiScale(src, 1.1, 3, HaarDetectionType.FindBiggestObject, new OpenCvSharp.Size(100, 100), new OpenCvSharp.Size(640, 480));

                var biggest = 0;
                var biggestRect = new Rect();
                var biggestRectloc = new Rect();
                float xAvg = 0;
                float yAvg = 0;
                float xAvgSize = 0;
                float yAvgSize = 0;
                foreach (Rect rect in matches)
                {

                    // the HOG detector returns slightly larger rectangles than the real objects.
                    // so we slightly shrink the rectangles to get a nicer output.
                    Rect r = new Rect
                    {
                        X = rect.X + (int)Math.Round(rect.Width * 0.1),
                        Y = rect.Y + (int)Math.Round(rect.Height * 0.1),
                        Width = (int)Math.Round(rect.Width * 0.8),
                        Height = (int)Math.Round(rect.Height * 0.8)
                    };
                    if (rect.Size.Height + rect.Size.Width > biggest)
                    {
                        biggestRect = r;
                        biggestRectloc = rect;
                    }
                    xAvgSize += r.Width;
                    yAvgSize += r.Height;
                    xAvg += rect.Location.X;
                    yAvg += rect.Location.Y;
                }
                if (matches.Length > 0)
                {
                    var avgLoc = new OpenCvSharp.Point((xAvg / matches.Length), (yAvg / matches.Length));

                    Rect rr = new Rect
                    {
                        X = avgLoc.X,
                        Y = avgLoc.Y,
                        Width = (int)xAvgSize / matches.Length,
                        Height = (int)yAvgSize / matches.Length,
                    };

                    src.Rectangle(rr.TopLeft, rr.BottomRight, Scalar.Red, 3, LineTypes.Link8, 0);
                    src.PutText("Griff", new OpenCvSharp.Point(rr.Location.X + 5, rr.Location.Y + 20), HersheyFonts.HersheyPlain, 2, Scalar.Red, 3, LineTypes.Link8);
                }
            }
            return src;
        }
    }
}
