using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Dto
{
    public class ListLotDriver
    {
        public string LoHID { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string Image { get; set; }
        public Boolean Available { get; set; }
    }
}