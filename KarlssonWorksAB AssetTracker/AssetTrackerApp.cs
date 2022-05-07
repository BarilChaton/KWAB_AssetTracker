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
            Console.SetWindowSize(160, 20);
            applogic app = new applogic();
            app.Start();
        }
    }
}
