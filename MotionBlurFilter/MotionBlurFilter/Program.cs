using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
namespace MotionBlurFilter
{
    class Program
    {       
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            //PC
            String imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "dog.jpg");  
            Bitmap bitmap = new Bitmap(imagePath);
            Bitmap temp = new Bitmap(bitmap);
            int numberOfThreads = 4;
            int radius = 25;
            float reciprocal = 1f / ((radius * 2) + 1);
            int width = bitmap.Width;
            int height = bitmap.Height;
            int chunkWidth = width / numberOfThreads;
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = bmpData.Scan0;
            BitmapData tempData = temp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr tempPtr = tempData.Scan0;
            Thread[] threads = new Thread[numberOfThreads];
            stopwatch.Start();
            for (int i = 0; i < numberOfThreads; i++)
            {
                int startX = i * chunkWidth; //Starting point for this thread
                int endX = (i == numberOfThreads - 1) ? width : (i + 1) * chunkWidth; //End point for this thread
                threads[i] = new Thread(() => ProcessChunkASM(ptr, tempPtr, startX, endX, width, height, radius));
                threads[i].Start();
            }
            foreach(Thread thread in threads)
            {
                thread.Join();
            }
            bitmap.UnlockBits(bmpData);
            temp.UnlockBits(tempData);
            stopwatch.Stop();
            Console.WriteLine("All threads finished in " + stopwatch.ElapsedMilliseconds + "ms!"); 
            String outputImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "blurredDog.jpg");
            temp.Save(outputImage, ImageFormat.Jpeg);
        }
        //PC
        [DllImport(@"C:\Users\mateu\OneDrive\Pulpit\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurASM.dll")]
        //Laptop
        //[DllImport(@"C:\Users\mateu\Desktop\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurASM.dll")]
        static extern void MyProc1(IntPtr ptr, IntPtr tempPtr, int startX, int endX, int width, int height, int radius);
        static void ProcessChunkASM(IntPtr ptr, IntPtr tempPtr, int startX, int endX, int width, int height, int radius)
        {
            MyProc1(ptr, tempPtr, startX, endX, width, height, radius);   
        }
        //PC
        [DllImport(@"C:\Users\mateu\OneDrive\Pulpit\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurC.dll")]
        //Laptop
        //[DllImport(@"C:\Users\mateu\Desktop\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurC.dll")]
        static extern void ApplyMotionBlur(IntPtr ptr, IntPtr tempPtr, int startX, int endX, int width, int height, int radius);
        static void ProcessChunkC(IntPtr ptr, IntPtr tempPtr, int startX, int endX, int width, int height, int radius)
        {
            Console.WriteLine("Thread " + startX + " - " + endX + " started.");
            ApplyMotionBlur(ptr, tempPtr, startX, endX, width, height, radius);
        }
    }
}

