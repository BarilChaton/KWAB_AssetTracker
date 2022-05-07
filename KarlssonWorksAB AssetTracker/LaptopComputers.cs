using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarlssonWorksAB_AssetTracker
{
    class LaptopComputers : BaseAssetStats
    {
        public LaptopComputers()
        {
        }

        public LaptopComputers(string office, DateTime purchaseDate, string brand, int price, string currency, string laptopModel) : base(office, brand, purchaseDate, price, currency)
        {
            LaptopModel = laptopModel;
        }

        public string LaptopModel { get; set; }
    }
}
