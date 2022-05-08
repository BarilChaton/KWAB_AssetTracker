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

        // Currency exchange rate (by 2022-05-08)
        static double usdSekEx = 9.95;
        static double euroUsdEx = 0.95;
        static double sekEuroEx = 10.49;

        // Offices variables. Really needed?
        static string sweden = "Sweden";
        static string france = "France";
        static string germany = "Germany";
        static string finland = "Finland";
        static string spain = "Spain";
        static string usa = "USA";

        // PC brands...
        static string apple = "Apple";
        static string lenovo = "Lenovo";
        static string hp = "HP";
        static string dell = "Dell";
        static string asus = "Asus";
        static string acer = "Acer";

        // Phone brands
        static string iPhone = "Apple";
        static string samsungPhone = "Samsung";
        static string huawei = "Huawei"; // ChujWie
        static string xiaomi = "Xiaomi";

        // Apple Models
        // Laptops
        static string MBP1 = "MacBook Pro 13-in (2016)";
        static string MBP2 = "MacBook Pro 13-in (2020)";
        static string MBP3 = "MacBook Pro 16-in (2019)";
        // Phones
        static string IPhone1 = "IPhone 4S";
        static string IPhone2 = "IPhone 5";
        static string IPhone3 = "IPhone 6";

        // Lenovo Models
        static string lenovo1 = "Lenovo IdeaPad Slim 5 (82FG01BAIN)";
        static string lenovo2 = "Lenovo ThinkPad E15 (Gen 2)";
        static string lenovo3 = "Lenovo IdeaPad Flex 3i 11.6-inch Chromebook";

        // HP Models
        static string hp1 = "HP Chromebook x360 14a";
        static string hp2 = "HP Envy 14-eb0021TX";
        static string hp3 = "HP Victus 16 E Series";

        // Dell Models
        static string dell1 = "Dell Latitude 3000";
        static string dell2 = "Dell Latitude 5000";
        static string dell3 = "Dell Latitude 7000";

        // Asus Models
        static string asusPC1 = "A42DE";
        static string asusPC2 = "A42F";
        static string asusPC3 = "A42JA";

        // Acer Models
        static string acer1 = "A111-31";
        static string acer2 = "A114-31";
        static string acer3 = "A114-32";

        // Samsung Models
        static string samsung1 = "Samsung Galaxy S6";
        static string samsung2 = "Samsung Galaxy S7";
        static string samsung3 = "Samsung Galaxy S8";

        // Huawei Models
        static string huawei1 = "Huawei Mate 10";
        static string huawei2 = "Huawei Mate 20";
        static string huawei3 = "Huawei Mate 30";

        // Xiaomi Models
        static string xiaomi1 = "Redmi 10A";
        static string xiaomi2 = "Redmi Note 10";
        static string xiaomi3 = "Redmi Note 11";

        // "Apple", "Samsung", "Huawei", "Xiaomi", "Asus", "Oppo", "Vivo", "Motorola", "LG", "Nokia"

        // "Apple", "Lenovo", "HP", "Dell", "Asus", "Acer", "IBM", "Raspberry PI", "Samsung", "Microsoft", "Packard Bell"

        //"Sweden", "France", "Germany", "Finland", "Spain", "United States of America"


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

            string[] options = { "Add an Asset", "Show list of Assets", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    AddAsset();
                    break;
                case 1:
                    ShowList();
                    break;
                case 2:
                    ShowList();
                    break;
                case 3:
                    break;
            }
        }


        // This methods job is to be able to add whatever the user inputs to the list declared above.
        private static void AddAsset()
        {
            Console.Clear();
            while (true)
            {
                // Create the asset object
                BaseAssetStats asset = new BaseAssetStats();
                //asset.Type = pC;

                //------------------------------------------------------------------
                // Ask user what type of asset is being added.
                string promptType = @"What type of asset do you wish to add?";
                string[] optionsType = { "Laptop", "Phone" };
                Menu typeMenu = new Menu(promptType, optionsType);
                int selectedIndexType = typeMenu.Run();
                switch(selectedIndexType)
                {
                    case 0:
                        asset.Type = pC;
                        break;
                    case 1:
                        asset.Type = mobilePhone;
                        break;
                }

                //------------------------------------------------------------------
                // Ask user to input purchase date.
                Console.WriteLine("Type in a purchase date of the computer asset (yyyy-mm-dd)");
                DateTime inputDate = DateTime.Parse(Console.ReadLine());

                // Put the purchase date into the object.
                asset.PurchaseDate = inputDate;

                //------------------------------------------------------------------
                // Ask the user which office the asset is based in.
                string promptOffice = @"Which office is the asset located in? (Country)";
                string[] optionsOffice = { "Sweden", "France", "Germany", "Finland", "Spain", "United States of America" };
                Menu officeMenu = new Menu(promptOffice, optionsOffice);
                int selectedIndexOffice = officeMenu.Run();
                switch(selectedIndexOffice)
                {
                    case 0 :
                        asset.Office = sweden;
                        break;
                    case 1 :
                        asset.Office = france;
                        break;
                    case 2 :
                        asset.Office = germany;
                        break;
                    case 3 :
                        asset.Office = finland;
                        break;
                    case 4:
                        asset.Office = spain;
                        break;
                    case 5:
                        asset.Office = usa;
                        break;
                }

                //------------------------------------------------------------------
                // Ask the user for brand depending if the asset is a computer or a phone.
                if (asset.Type == pC)
                {
                    string promptBrand = @"Select the brand of the computer asset.";
                    string[] optionsBrand = { "Apple", "Lenovo", "HP", "Dell", "Asus", "Acer" };
                    Menu brandMenu = new Menu(promptBrand, optionsBrand);
                    int selectedIndexBrand = brandMenu.Run();
                    switch (selectedIndexBrand)
                    {
                        // This is a long switch :D
                        // I <3 Switch :D
                        case 0 :
                            asset.Brand = apple;
                            break;
                        case 1 :
                            asset.Brand = lenovo;
                            break;
                        case 2 :
                            asset.Brand = hp;
                            break;
                        case 3 :
                            asset.Brand = dell;
                            break;
                        case 4 :
                            asset.Brand = asus;
                            break;
                        case 5 :
                            asset.Brand = acer;
                            break;

                    }
                }
                else if (asset.Type == mobilePhone)
                {
                    string promptBrand = @"Select the brand of the phone asset.";
                    string[] optionsBrand = { "Apple", "Samsung", "Huawei", "Xiaomi" };
                    Menu brandMenu = new Menu(promptBrand, optionsBrand);
                    int selectedIndexBrand = brandMenu.Run();
                    switch (selectedIndexBrand)
                    {
                        // I <3 Switch :D
                        case 0 :
                            asset.Brand = iPhone;
                            break;
                        case 1 :
                            asset.Brand = samsungPhone;
                            break;
                        case 2 :
                            asset.Brand = huawei;
                            break;
                        case 3 :
                            asset.Brand = xiaomi;
                            break;
                    }
                }

                

                //------------------------------------------------------------------
                // Ask the user for the model depending if the asset is a computer or a phone.
                // There will be tons of switches here...
                if (asset.Type == pC)
                {
                    if (asset.Brand == apple)
                    {
                        string promptModel = @"Select the model of the computer asset.";
                        string[] optionsModel = { MBP1, MBP2, MBP3 };
                        Menu modelMenu = new Menu(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0 :
                                asset.LaptopModel = MBP1;
                                break;
                            case 1 :
                                asset.LaptopModel = MBP2;
                                break;
                            case 3 :
                                asset.LaptopModel = MBP3;
                                break;
                        }
                    }
                    else if (asset.Brand == lenovo)
                    {
                        string promptModel = @"Select the model of the computer asset.";
                        string[] optionsModel = { lenovo1, lenovo2, lenovo3 };
                        Menu modelMenu = new Menu(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0 :
                                asset.LaptopModel = lenovo1;
                                break;
                            case 1 :
                                asset.LaptopModel = lenovo2;
                                break;
                            case 3 :
                                asset.LaptopModel = lenovo3;
                                break;
                        }
                    }
                    else if (asset.Brand == hp)
                    {
                        string promptModel = @"Select the model of the computer asset.";
                        string[] optionsModel = { hp1, hp2, hp3 };
                        Menu modelMenu = new Menu(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0 :
                                asset.LaptopModel = hp1;
                                break;
                            case 1 :
                                asset.LaptopModel = hp2;
                                break;
                            case 3 :
                                asset.LaptopModel = hp3;
                                break;
                        }
                    }
                    else if (asset.Brand == dell)
                    {
                        string promptModel = @"Select the model of the computer asset.";
                        string[] optionsModel = { dell1, dell2, dell3 };
                        Menu modelMenu = new Menu(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0 :
                                asset.LaptopModel = dell1;
                                break;
                            case 1 :
                                asset.LaptopModel = dell2;
                                break;
                            case 3 :
                                asset.LaptopModel = dell3;
                                break;
                        }
                    }
                    else if (asset.Brand == asus)
                    {
                        string promptModel = @"Select the model of the computer asset.";
                        string[] optionsModel = { asusPC1, asusPC2, asusPC3 };
                        Menu modelMenu = new Menu(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0 :
                                asset.LaptopModel = asusPC1;
                                break;
                            case 1 :
                                asset.LaptopModel = asusPC2;
                                break;
                            case 3 :
                                asset.LaptopModel = asusPC3;
                                break;
                        }
                    }
                    else if (asset.Brand == acer)
                    {
                        string promptModel = @"Select the model of the computer asset.";
                        string[] optionsModel = { acer1, acer2, acer3 };
                        Menu modelMenu = new Menu(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0 :
                                asset.LaptopModel = acer1;
                                break;
                            case 1 :
                                asset.LaptopModel = acer2;
                                break;
                            case 3 :
                                asset.LaptopModel = acer3;
                                break;
                        }
                    }
                }
                else if(asset.Type == mobilePhone)
                {
                    if (asset.Brand == iPhone)
                    {
                        string promptModel = @"Select the model of the phone asset.";
                        string[] optionsModel = { IPhone1, IPhone2, IPhone3 };
                        Menu modelMenu = new Menu(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0 :
                                asset.PhoneModel = IPhone1;
                                break;
                            case 1 :
                                asset.PhoneModel = IPhone2;
                                break;
                            case 3 :
                                asset.PhoneModel = IPhone3;
                                break;
                        }
                    }
                    else if (asset.Brand == samsungPhone)
                    {
                        string promptModel = @"Select the model of the phone asset.";
                        string[] optionsModel = { samsung1, samsung2, samsung3 };
                        Menu modelMenu = new Menu(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0 :
                                asset.PhoneModel = samsung1;
                                break;
                            case 1 :
                                asset.PhoneModel = samsung2;
                                break;
                            case 3 :
                                asset.PhoneModel = samsung3;
                                break;
                        }
                    }
                    else if (asset.Brand == huawei)
                    {
                        string promptModel = @"Select the model of the phone asset.";
                        string[] optionsModel = { huawei1, huawei2, huawei3 };
                        Menu modelMenu = new Menu(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0 :
                                asset.PhoneModel = huawei1;
                                break;
                            case 1 :
                                asset.PhoneModel = huawei2;
                                break;
                            case 3 :
                                asset.PhoneModel = huawei3;
                                break;
                        }
                    }
                    else if (asset.Brand == xiaomi)
                    {
                        string promptModel = @"Select the model of the phone asset.";
                        string[] optionsModel = { xiaomi1, xiaomi2, xiaomi3 };
                        Menu modelMenu = new Menu(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0 :
                                asset.PhoneModel = xiaomi1;
                                break;
                            case 1 :
                                asset.PhoneModel = xiaomi2;
                                break;
                            case 3 :
                                asset.PhoneModel = xiaomi3;
                                break;
                        }
                    }
                }

                //------------------------------------------------------------------
                // Change this so the user is not asked but rather the program detects at which country the asset is bought.
                // And then sets the what type of currency was used on its own.
                // It also tells the user in which currency it is supposed to be written in.
                
                // For Euro
                if (asset.Office == france || asset.Office == germany || asset.Office == finland || asset.Office == spain)
                {
                    asset.Currency = euro;
                }
                // For SEK
                else if (asset.Office == sweden)
                {
                    asset.Currency = sek;
                }
                // For USD
                else if (asset.Office == usa)
                {
                    asset.Currency = usd;
                }

                //------------------------------------------------------------------
                // Ask the user for the price depending on the selected country (do it in double)
                
                // For Euro
                if (asset.Office == france || asset.Office == germany || asset.Office == finland || asset.Office == spain)
                {
                    Console.WriteLine("What was the price of the asset in Euros?");
                }
                // For SEK
                else if (asset.Office == sweden)
                {
                    Console.WriteLine("What was the price of the asset in Swedish Krona?");
                }
                // For USD
                else if (asset.Office == usa)
                {
                    Console.WriteLine("What was the price of the asset in US Dollars?");
                }

                string inputPrice = Console.ReadLine();
                double dblAssetPrice = Convert.ToDouble(inputPrice);

                // Put the integer into the 'asset' object.
                asset.Price = dblAssetPrice;

                // Setup the exchange rate to USD
                if (asset.Currency == sek)
                {
                    asset.Price /= usdSekEx;
                }
                else if (asset.Currency == euro)
                {
                    asset.Price /= euroUsdEx;
                }

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
                    AddAsset();
                    break;
                }
            }
        }

        

        private static void ShowList()
        {
            Console.Clear();
            Console.WriteLine("Assets:\n");
            Console.WriteLine("Type".PadRight(20) + "Brand".PadRight(20) + "Model".PadRight(30) + "Purchase Date".PadRight(20) + "Office:".PadRight(20) + "Price(USD)".PadRight(20) + "Purchase Currency".PadRight(20) + "Local Price".PadRight(20));
            Console.WriteLine();
            foreach (BaseAssetStats asset in assets)
            {
                if (asset.Type == pC)
                {
                    Console.WriteLine(asset.Type.PadRight(20) + asset.Brand.PadRight(20) + asset.LaptopModel.PadRight(30) + asset.PurchaseDate.ToString("yyyy-MM-dd").PadRight(20) + asset.Office.PadRight(20) + asset.Price.ToString("0.00").PadRight(20) + asset.Currency.PadRight(20) + asset.LocalPrice.ToString("0.00").PadRight(20));
                }
                if (asset.Type == mobilePhone)
                {
                    Console.WriteLine(asset.Type.PadRight(20) + asset.Brand.PadRight(20) + asset.PhoneModel.PadRight(30) + asset.PurchaseDate.ToString("yyyy-MM-dd").PadRight(20) + asset.Office.PadRight(20) + asset.Price.ToString("0.00").PadRight(20) + asset.Currency.PadRight(20) + asset.LocalPrice.ToString("0.00").PadRight(20));
                }
                
            }

            Console.ReadLine();
        }
    }
}
