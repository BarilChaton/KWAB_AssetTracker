using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarlssonWorksAB_AssetTracker
{
    class MobilePhones : BaseAssetStats
    {
        // class irrelevant but left here just in case.
        public MobilePhones()
        {
        }

        public MobilePhones(string office, DateTime purchaseDate, string phoneModel, string brand, int price, string currency)
        {
            PhoneModel = phoneModel;
        }

        public string PhoneModel { get; set; }
    }
}
