using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Admin.Models.Dto
{
    public class HostRequestDTO
    {
        public string ID { get; set; }
        public string Fullname { get; set; }
        public string LoHID { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
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