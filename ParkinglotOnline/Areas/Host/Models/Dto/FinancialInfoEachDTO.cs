using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.Models.Dto
{
    public class FinancialInfoEachDTO
    {
        public string LotID { get; set; }
        public double UnitPrice { get; set; }
        public string Name { get; set; }
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