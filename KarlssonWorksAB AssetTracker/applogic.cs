using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarlssonWorksAB_AssetTracker
{
    class applogic
    {
        // This class contains all the workings of the asset tracking program.
        // My solution to it was to set it up by using 4 methods one of which is called from a diffirent class,
        // And the others in a switch statement. Essential lists, items and variables are declared as early as possible in the class.
        // Because I find it more managable to read and edit it if needed.

        //Create the lists
        static List<BaseAssetStats> assets = new List<BaseAssetStats>();
        //static List<MobilePhones> mobilePhones = new List<MobilePhones>();

        // Currency Variables.
        static string sek = "SEK";
        static string euro = "EUR";
        static string usd = "USD";

        // Type variables.
        static string pC = "Laptop";
        static string mobilePhone = "Phone";

        // Eventual variables.

        public void Start()
        {
            Console.Clear();
            // the greeting
            string prompt = @"Welcome to the Asset Tracker program." +
                                "\nPlease select what you wish to do.\n\n";

            string[] options = { "Add Computer Asset", "Add Phone Asset", "Show list of Assets" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    AddPC();
                    break;
                case 1:
                    AddPhone();
                    break;
                case 2:
                    ShowList();
                    break;
            }
        }


        // This methods job is to be able to add whatever the user inputs to the list declared above.
        private static void AddPC()
        {
            Console.Clear();
            while (true)
            {
                // Create the object 'computer'
                BaseAssetStats asset = new BaseAssetStats();
                asset.Type = pC;
                
                //------------------------------------------------------------------
                // Ask user to input purchase date.
                Console.WriteLine("Type in a purchase date of the computer asset (yyyy-mm-dd)");
                DateTime inputDate = DateTime.Parse(Console.ReadLine());

                // Put the purchase date into the object.
                asset.PurchaseDate = inputDate;

                //------------------------------------------------------------------
                // Ask the user which office the asset is based in.
                Console.WriteLine("Which office is the asset located in? (Country)");
                //Maybe there should be a predetermined list on which country the asset is in.
                string inputLocation = Console.ReadLine();

                // Put the location variable inte the computer object.
                asset.Office = inputLocation;

                //------------------------------------------------------------------
                // Ask the user for brand.
                Console.WriteLine("Type in the brand name of the computer asset.");
                string inputBrand = Console.ReadLine();

                // Put the brand name variable into the 'computer' object.
                asset.Brand = inputBrand;

                //------------------------------------------------------------------
                // Ask the user for the model
                Console.WriteLine("Type in the model of the computer asset.");
                string inputModel = Console.ReadLine();

                // Put the model name into the 'computer' object.
                asset.LaptopModel = inputModel;
                //------------------------------------------------------------------
                // Ask the user in which currency the asset was pruchased.
                string prompt = @"What currency was this asset purchased with?";
                string[] options = { "SEK", "EUR", "USD" };
                Menu currencyMenu = new Menu(prompt, options);
                int selectedIndex = currencyMenu.Run();
                switch (selectedIndex)
                {
                    case 0:
                        asset.Currency = sek;
                        break;
                    case 1:
                        asset.Currency = euro;
                        break;
                    case 2:
                        asset.Currency = usd;
                        break;
                }

                //------------------------------------------------------------------
                // Ask the user for the price (do it in int)
                Console.WriteLine("What was the price of the asset?");
                string inputPrice = Console.ReadLine();
                int intComputerPrice = Convert.ToInt32(inputPrice);

                // Put the integer into the 'computer' object.
                asset.Price = intComputerPrice;

                //------------------------------------------------------------------
                // Put the object into the list.
                assets.Add(asset);

                // Ask user if user wish to add another asset.
                Console.WriteLine("Do you wish to add another computer asset? Y/N");
                if (Console.ReadLine().ToLower().Trim() == "n")
                {
                    applogic start = new applogic();
                    start.Start();
                    break;
                }
                else if (Console.ReadLine().ToLower().Trim() == "y")
                {
                    AddPC();
                    break;
                }
            }
        }

        private static void AddPhone()
        {
            Console.Clear();
            while (true)
            {
                // Create the object 'phone'
                BaseAssetStats asset = new BaseAssetStats();
                asset.Type = mobilePhone; // Maybe add this as a choice thing for a user instead of making user choose what to add at start...

                //------------------------------------------------------------------
                // Ask user to input purchase date.
                Console.WriteLine("Type in a purchase date of the phone asset (yyyy-mm-dd)");
                DateTime inputDate = DateTime.Parse(Console.ReadLine());

                // Put the purchase date into the object.
                asset.PurchaseDate = inputDate;

                //------------------------------------------------------------------
                // Ask the user which office the asset is based in.
                Console.WriteLine("Which office is the asset located in?");
                string inputLocation = Console.ReadLine();

                // Put the location variable inte the computer object.
                asset.Office = inputLocation;

                //------------------------------------------------------------------
                // Ask the user for brand.
                Console.WriteLine("Type in the brand name of the phone asset.");
                string inputBrand = Console.ReadLine();

                // Put the brand name variable into the 'computer' object.
                asset.Brand = inputBrand;

                //------------------------------------------------------------------
                // Ask the user for the model
                Console.WriteLine("Type in the model of the phone asset.");
                string inputModel = Console.ReadLine();

                // Put the model name into the 'computer' object.
                asset.LaptopModel = inputModel;

                //------------------------------------------------------------------
                // Ask the user in which currency the asset was pruchased.
                string prompt = @"What currency was this asset purchased with?";
                string[] options = { "SEK", "EUR", "USD" };
                Menu currencyMenu = new Menu(prompt, options);
                int selectedIndex = currencyMenu.Run();
                switch (selectedIndex)
                {
                    case 0:
                        asset.Currency = sek;
                        break;
                    case 1:
                        asset.Currency = euro;
                        break;
                    case 2:
                        asset.Currency = usd;
                        break;
                }

                //------------------------------------------------------------------
                // Ask the user for the price (do it in int)
                Console.WriteLine("What was the price of the asset?");
                string inputPrice = Console.ReadLine();
                int intComputerPrice = Convert.ToInt32(inputPrice);

                // Put the integer into the 'phone' object.
                asset.Price = intComputerPrice;

                //------------------------------------------------------------------
                // Put the object into the list.
                assets.Add(asset);

                // Ask user if user wish to add another asset.
                Console.WriteLine("Do you wish to add another phone asset? Y/N");
                if (Console.ReadLine().ToLower().Trim() == "n")
                {
                    applogic start = new applogic();
                    start.Start();
                    break;
                }
                else if (Console.ReadLine().ToLower().Trim() == "y")
                {
                    AddPhone();
                    break;
                }
            }
        }

        private static void ShowList()
        {
            Console.WriteLine("Assets:\n");
            Console.WriteLine("Type".PadRight(24) + "Brand".PadRight(24) + "Model".PadRight(15) + "Purchase Date".PadRight(22) + "Office:".PadRight(16) + "Price".PadRight(23) + "Purchase Currency".PadRight(20));
            Console.WriteLine();
            foreach (BaseAssetStats asset in assets)
            {
                Console.WriteLine(asset.Type.PadRight(23) + " " + asset.Brand.PadRight(23) + " " + asset.LaptopModel.PadRight(14) + " " + asset.PurchaseDate.ToString("yyyy-MM-dd").PadRight(21) + " " + asset.Office.PadRight(15) + " " + asset.Price.ToString().PadRight(22) + " " + asset.Currency.PadRight(19));
            }

            Console.ReadLine();
        }
    }
}
