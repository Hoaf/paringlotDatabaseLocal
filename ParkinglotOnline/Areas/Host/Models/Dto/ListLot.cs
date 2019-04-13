using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.Dto
{
    public class ListLot
    {
        public string ID { get; set; }
        public string LoHID { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string Image { get; set; }
        public Boolean Available { get; set; }
        public string FormatPrice
        {
            get
            {
                if (UnitPrice > 1000)
                {
                    return String.Format("{0:n}", UnitPrice);
                }
                return UnitPrice + "";
            }
        }
    }
}