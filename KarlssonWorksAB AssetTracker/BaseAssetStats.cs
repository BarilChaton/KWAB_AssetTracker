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

        public BaseAssetStats(string office, string brand, DateTime purchaseDate, int price, string currency, string laptopModel, string phoneModel, string type)
        {
            Office = office;
            Brand = brand;
            PurchaseDate = purchaseDate;
            Price = price;
            Currency = currency;
            LaptopModel = laptopModel;
            PhoneModel = phoneModel;
            Type = type;
        }

        public string Office { get; set; }
        public string Brand { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
        public string LaptopModel { get; set; }
        public string PhoneModel { get; set; }
        public string Type { get; set; }

    }
}
