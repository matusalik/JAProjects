using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MotionBlurFilter
{
    class Program
    {
        [DllImport(@"C:\Users\mateu\OneDrive\Pulpit\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurASM.dll")]
        static extern int MyProc1(int a, int b);
        [DllImport(@"C:\Users\mateu\OneDrive\Pulpit\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurC.dll")]
        static extern int add(int a, int b);
        static void Main(string[] args)
        {
            int x = 5, y = 3;
            int retValasm = MyProc1(x, y);
            int retValC = add(x, y);
            Console.Write("Moja pierwsza wartość obliczona w asm to:");
            Console.WriteLine(retValasm);
            Console.Write("Moja pierwsza wartość obliczona w C to:");
            Console.WriteLine(retValC);
        }
    }
}

