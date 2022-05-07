using System;
using System.Collections.Generic;
using System.Linq;


namespace KarlssonWorksAB_AssetTracker
{
    internal class AssetTrackerApp
    {
        // Create appropriate lists..
        static List<LaptopComputers> LaptopAssets = new List<LaptopComputers>();
        static List<MobilePhones> MobileAssets = new List<MobilePhones>();
        static void Main(string[] args)
        {
            Console.SetWindowSize(160, 20); // Sets window size (does only work for the windows system.)
            applogic app = new applogic();  // Calls the applogic class.
            app.Start();                    // Calls the start method of the said class. (Essentially runs the program.) I find it more efficient to do it this way.
        }
    }
}
