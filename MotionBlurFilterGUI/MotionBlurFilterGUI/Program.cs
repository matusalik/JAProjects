using System.Runtime.InteropServices;

namespace MotionBlurFilterGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            String workingDirectory = Directory.GetCurrentDirectory();
            workingDirectory = Directory.GetParent(workingDirectory).FullName;
            string[] parts = workingDirectory.Split('\\');
            string desiredPart = "\\" + parts[^2] + "\\" + parts[^1];
            workingDirectory = Directory.GetParent(workingDirectory).FullName;
            workingDirectory = Directory.GetParent(workingDirectory).FullName;
            workingDirectory = Directory.GetParent(workingDirectory).FullName;
            workingDirectory = Directory.GetParent(workingDirectory).FullName;
            workingDirectory += desiredPart;

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        //PC
        [DllImport("MotionBlurC.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ApplyMotionBlur(IntPtr ptr, IntPtr tempPtr, int startX, int endX, int width, int height, int radius);
        public static void ProcessChunkC(IntPtr ptr, IntPtr tempPtr, int startX, int endX, int width, int height, int radius)
        {
            ApplyMotionBlur(ptr, tempPtr, startX, endX, width, height, radius);
        }

        //PC
        [DllImport("MotionBlurASM.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void MyProc1(IntPtr ptr, IntPtr tempPtr, int startX, int endX, int width, int height, int radius);
        public static void ProcessChunkASM(IntPtr ptr, IntPtr tempPtr, int startX, int endX, int width, int height, int radius)
        {
            MyProc1(ptr, tempPtr, startX, endX, width, height, radius);
        }
    }
}