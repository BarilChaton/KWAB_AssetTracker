﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarlssonWorksAB_AssetTracker
{
    class applogic
    {
        //Create the lists
        static List<LaptopComputers> computers = new List<LaptopComputers>();
        static List<MobilePhones> mobilePhones = new List<MobilePhones>();

        // Currency Variables.
        static string sek = "SEK";
        static string euro = "EUR";
        static string usd = "USD";

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
                LaptopComputers computer = new LaptopComputers();
                
                //------------------------------------------------------------------
                // Ask user to input purchase date.
                Console.WriteLine("Type in a purchase date of the computer asset (yyyy-mm-dd)");
                DateTime inputDate = DateTime.Parse(Console.ReadLine());

                // Put the purchase date into the object.
                computer.PurchaseDate = inputDate;

                //Print for testing purposes. Delet when method is done.
                Console.WriteLine(computer.PurchaseDate.ToString("yyyy-MM-dd"));

                //------------------------------------------------------------------
                // Ask the user which office the asset is based in.
                Console.WriteLine("Which office is the asset located in?");
                string inputLocation = Console.ReadLine();

                // Put the location variable inte the computer object.
                computer.Office = inputLocation;

                //------------------------------------------------------------------
                // Ask the user for brand.
                Console.WriteLine("Type in the brand name of the computer asset.");
                string inputBrand = Console.ReadLine();

                // Put the brand name variable into the 'computer' object.
                computer.Brand = inputBrand;

                //------------------------------------------------------------------
                // Ask the user for the model
                Console.WriteLine("Type in the model of the computer asset.");
                string inputModel = Console.ReadLine();

                // Put the model name into the 'computer' object.
                computer.LaptopModel = inputModel;

                //------------------------------------------------------------------
                // Ask the user for the price (do it in int)
                Console.WriteLine("What was the price of the asset in SEK?");
                string inputPrice = Console.ReadLine();
                int intComputerPrice = Convert.ToInt32(inputPrice);

                // Put the integer into the 'computer' object.
                computer.Price = intComputerPrice;

                //------------------------------------------------------------------
                // Ask the user in which currency the asset was pruchased.
                string prompt = @"What currency was this asset purchased with?";
                string[]options = { "SEK", "EUR", "USD" };
                Menu currencyMenu = new Menu(prompt, options);
                int selectedIndex = currencyMenu.Run();
                switch (selectedIndex) 
                {
                    case 0 :
                        computer.Currency = sek;
                        break;
                    case 1 :
                        computer.Currency = euro;
                        break;
                    case 2 :
                        computer.Currency = usd;
                        break;
                }


                //------------------------------------------------------------------
                // Put the object into the list.
                computers.Add(computer);

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

        private static void ShowList()
        {
            Console.WriteLine("Computer Assets:\n");
            Console.WriteLine("Computer Brand".PadRight(24) + "Model".PadRight(15) + "Purchase Date".PadRight(22) + "Office:".PadRight(16) + "Price(in SEK)".PadRight(23) + "Purchase Currency".PadRight(20));
            Console.WriteLine("¤======================================================================================================================¤");
            foreach (LaptopComputers computer in computers)
            {
                Console.WriteLine(computer.Brand.PadRight(23) + " " + computer.LaptopModel.PadRight(14) + " " + computer.PurchaseDate.ToString("yyyy-MM-dd").PadRight(21) + " " + computer.Office.PadRight(15) + " " + computer.Price.ToString().PadRight(22) + " " + computer.Currency.PadRight(19));
            }
            Console.ReadLine();
        }
    }
}
