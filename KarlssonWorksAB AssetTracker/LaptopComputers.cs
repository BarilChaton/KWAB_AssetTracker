using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarlssonWorksAB_AssetTracker
{
    class LaptopComputers : BaseAssetStats
    {
        // class irrelevant but left here just in case.
        public LaptopComputers()
        {
        }

        public LaptopComputers(string office, DateTime purchaseDate, string brand, int price, string currency, string laptopModel)
        {
            LaptopModel = laptopModel;
        }

        public string LaptopModel { get; set; }
    }
}
