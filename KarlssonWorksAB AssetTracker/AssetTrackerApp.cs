using System;
using System.Runtime.InteropServices;

namespace KarlssonWorksAB_AssetTracker
{
    class AssetTrackerApp
    {
        // This sets up so the console will go full screen.
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        static void Main(string[] args)
        {
            // Apply Fullscreen. (Does only work for windows system.)
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);


            //Console.SetWindowSize(220, 40); // Sets window size (does only work for the windows system.)

            applogic app = new applogic();  // Calls the applogic class.
            app.Start();                    // Calls the start method of the said class. (Essentially runs the program.) I find it more efficient to do it this way.
        }
    }
}
