using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarlssonWorksAB_AssetTracker
{
    class BaseAssetStats
    {
        public BaseAssetStats()
        {
        }

        public BaseAssetStats(string office, string brand, DateTime purchaseDate, double price, string currency, string laptopModel, string phoneModel, string type, double localPrice)
        {
            Office = office;
            Brand = brand;
            PurchaseDate = purchaseDate;
            Price = price;
            Currency = currency;
            LaptopModel = laptopModel;
            PhoneModel = phoneModel;
            Type = type;
            LocalPrice = localPrice;
        }

        public string Office { get; set; }
        public string Brand { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string LaptopModel { get; set; }
        public string PhoneModel { get; set; }
        public string Type { get; set; }
        public double LocalPrice { get; set; }

    }
}
