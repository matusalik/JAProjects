﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MotionBlurFilter
{
    class Program
    {

        [DllImport(@"C:\Users\mateu\OneDrive\Pulpit\MotionBlurFilter\x64\Debug\MotionBlurASM.dll")]
        static extern int MyProc1(int a, int b);
        static void Main(string[] args)
        {
            int x = 5, y = 3;
            int retVal = MyProc1(x, y);
            Console.Write("Moja pierwsza wartość obliczona w asm to:");
            Console.WriteLine(retVal);
        }
    }
}

