using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
namespace MotionBlurFilter
{
    class Program
    {       
        static void Main(string[] args)
        {
            //PC
            Bitmap bitmap = new Bitmap("C:\\Users\\mateu\\OneDrive\\Pulpit\\JAProjects\\MotionBlurFilter\\MotionBlurFilter\\Resources\\dog.jpg");
            //Laptop
            //Bitmap bitmap = new Bitmap("C:\\Users\\mateu\\Desktop\\JAProjects\\MotionBlurFilter\\MotionBlurFilter\\Resources\\dog.jpg");
            int numberOfThreads = 10;
            int radius = 5;
            int width = bitmap.Width;
            int height = bitmap.Height;
            int chunkWidth = width / numberOfThreads;
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = bmpData.Scan0;
            Thread[] threads = new Thread[numberOfThreads];
            for (int i = 0; i < numberOfThreads; i++){
                int startX = i * chunkWidth; //Starting point for this thread
                int endX = (i == numberOfThreads - 1) ? width : (i + 1) * chunkWidth; //End point for this thread
                threads[i] = new Thread(() => ProcessChunkC(ptr, startX, endX, width, height, radius));
                threads[i].Start();
            }
            foreach(Thread thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine("All threads finished!");
            bitmap.UnlockBits(bmpData);
            bitmap.Save("C:\\Users\\mateu\\OneDrive\\Pulpit\\JAProjects\\MotionBlurFilter\\MotionBlurFilter\\Resources\\blurred_dog.jpg", ImageFormat.Jpeg);
        }
        //PC
        [DllImport(@"C:\Users\mateu\OneDrive\Pulpit\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurASM.dll")]
        //Laptop
        //[DllImport(@"C:\Users\mateu\Desktop\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurASM.dll")]
        static extern int MyProc1();
        static void ProcessChunkASM(Bitmap image, int startX, int endX, int height)
        {
            Console.WriteLine("Starting thread with a starting point of: " + startX);
        }
        //PC
        [DllImport(@"C:\Users\mateu\OneDrive\Pulpit\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurC.dll")]
        //Laptop
        //[DllImport(@"C:\Users\mateu\Desktop\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurC.dll")]
        static extern void ApplyMotionBlur(IntPtr ptr, int startX, int endX, int width, int height, int radius);
        static void ProcessChunkC(IntPtr ptr, int startX, int endX, int width, int height, int radius)
        {
            Console.WriteLine("Thread " + startX + " - " + endX + " started.");
            ApplyMotionBlur(ptr, startX, endX, width, height, radius);
        }
    }
}

