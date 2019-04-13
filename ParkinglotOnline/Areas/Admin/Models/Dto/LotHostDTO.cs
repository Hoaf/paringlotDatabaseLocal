using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Admin.Models.Dto
{
    public class LotHostDTO
    {
        public string LoHID { get; set; }
        public bool Available { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
    }
}