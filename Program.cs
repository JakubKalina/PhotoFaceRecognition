using System;
using DlibDotNet;

namespace DetectFaces
{
    class Program
    {
        // Path to a input file
        private const string inputFilePath = "./input.jpg";

        // The main program entry point
        static void Main(string[] args)
        {
            using (var fd = Dlib.GetFrontalFaceDetector())
            {
                // Load input picture
                var img = Dlib.LoadImage<RgbPixel>(inputFilePath);

                // Find all faces in the image
                var faces = fd.Operator(img);

                foreach (var face in faces)
                {
                    Dlib.DrawRectangle(img, face, color: new RgbPixel(0,255,255), thickness: 3);
                }

                Dlib.SaveJpeg(img, "output.jpg");

            }
        }
    }
}
