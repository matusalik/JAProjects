using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
namespace MotionBlurFilter
{
    class Program
    {       
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            //PC
            //Bitmap bitmap = new Bitmap("C:\\Users\\mateu\\OneDrive\\Pulpit\\JAProjects\\MotionBlurFilter\\MotionBlurFilter\\Resources\\dog.jpg");
            //Laptop
            Bitmap bitmap = new Bitmap("C:\\Users\\mateu\\Desktop\\JAProjects\\MotionBlurFilter\\MotionBlurFilter\\Resources\\test.jpg");
            Bitmap temp = new Bitmap(bitmap);
            int numberOfThreads = 4;
            int radius = 25;
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
                //threads[i] = new Thread(() => ProcessChunkC(ptr, tempPtr, startX, endX, width, height, radius));
                //threads[i].Start();
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
            temp.Save("C:\\Users\\mateu\\Desktop\\JAProjects\\MotionBlurFilter\\MotionBlurFilter\\Resources\\blurredTest.jpg", ImageFormat.Jpeg);
        }
        //PC
        //[DllImport(@"C:\Users\mateu\OneDrive\Pulpit\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurASM.dll")]
        //Laptop
        [DllImport(@"C:\Users\mateu\Desktop\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurASM.dll")]
        static extern void MyProc1(IntPtr ptr, IntPtr tempPtr, int startX, int endX, int width, int height, int radius);
        static void ProcessChunkASM(IntPtr ptr, IntPtr tempPtr, int startX, int endX, int width, int height, int radius)
        {
            MyProc1(ptr, tempPtr, startX, endX, width, height, radius);   
        }
        //PC
        //[DllImport(@"C:\Users\mateu\OneDrive\Pulpit\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurC.dll")]
        //Laptop
        [DllImport(@"C:\Users\mateu\Desktop\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurC.dll")]
        static extern void ApplyMotionBlur(IntPtr ptr, IntPtr tempPtr, int startX, int endX, int width, int height, int radius);
        static void ProcessChunkC(IntPtr ptr, IntPtr tempPtr, int startX, int endX, int width, int height, int radius)
        {
            Console.WriteLine("Thread " + startX + " - " + endX + " started.");
            ApplyMotionBlur(ptr, tempPtr, startX, endX, width, height, radius);
        }
    }
}

