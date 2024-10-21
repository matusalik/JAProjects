using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
public class ASM {
    [DllImport(@"C:\Users\mateu\OneDrive\Pulpit\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurASM.dll")]
    static extern int MyProc1(int a, int b);
    public void CallAsmProcedure() {
        int x = 10, y = 15;
        int res = MyProc1(x, y);
        Console.Write("Wartości dodane w ASM: ");
        Console.WriteLine(res);
    }
}
public class C{
    [DllImport(@"C:\Users\mateu\OneDrive\Pulpit\JAProjects\MotionBlurFilter\x64\Debug\MotionBlurC.dll")]
    static extern int add(int a, int b);
    public void CallCFunction(){
        int x = 10, y = 15;
        int res = add(x, y);
        Console.Write("Wartości dodane w C: ");
        Console.WriteLine(res);
    }
}
namespace MotionBlurFilter
{
    class Program
    {       
        static void Main(string[] args)
        {
            ASM asm = new ASM();
            Thread threadAsm = new Thread(new ThreadStart(asm.CallAsmProcedure));
            threadAsm.Start();
            C c = new C();
            Thread threadC = new Thread(new ThreadStart(c.CallCFunction));
            threadC.Start();
        }
    }
}

