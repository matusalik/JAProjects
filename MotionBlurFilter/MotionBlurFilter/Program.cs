using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
namespace MotionBlurFilter
{
    class Program
    {       
        static void Main(string[] args)
        {
            //PC
            Bitmap bitmap = new Bitmap("C:\\Users\\mateu\\OneDrive\\Pulpit\\JAProjects\\MotionBlurFilter\\MotionBlurFilter\\Resources\\dog.jpg");
            int numberOfThreads = 4;
            int width = bitmap.Width;
            int height = bitmap.Height;
            int chunkWidth = width / numberOfThreads;
            Console.WriteLine(width);
            Console.WriteLine(height);
            Console.WriteLine(chunkWidth);
            for (int i = 0; i < numberOfThreads; i++){
                int startX = i * chunkWidth; //Starting point for this thread
                int endX = (i == numberOfThreads - 1) ? width : (i + 1) * chunkWidth; //End point for this thread
                Thread asmThread = new Thread(() => ProcessChunkASM(bitmap, startX, endX, height));
                asmThread.Start();
            }

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
        static extern int add(int a, int b);
        static void ProcessChunkC(Bitmap image, int startX, int endX, int height)
        {

        }
    }
}

