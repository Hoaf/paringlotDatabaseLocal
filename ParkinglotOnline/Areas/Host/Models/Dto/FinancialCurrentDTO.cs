using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.Models.Dto
{
    public class FinancialCurrentDTO
    {
        public int ID { get; set; }
        public string DriverID { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime ExitDateTime { get; set; }
    }
}