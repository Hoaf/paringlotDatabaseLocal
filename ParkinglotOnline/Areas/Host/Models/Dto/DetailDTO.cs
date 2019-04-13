using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.Dto
{


    public class DetailDTO
    {
        
        public string Username { get; set; }
        public int PhoneNumber { get; set; }
        public int ID { get; set; }
        public DateTime EntryDateTime { get ; set; }
        // public DateTime ExistDateTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string Image { get; set; }
        public double UnitPrice { get; set; }
        public string Name { get; set; }
        private DateTime DateTimeNow = DateTime.Now;
        private TimeSpan totalTime
        {
            get
            {               
                return (DateTimeNow - EntryDateTime);
            }
        }
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string TotalPrice
        {
            get
            {
                if (totalTime.TotalHours <=1 )
                {
                    return String.Format("{0:n}", Math.Round(UnitPrice));
                }
                return String.Format("{0:n}", Math.Round(UnitPrice + (totalTime.TotalHours - 1) * (UnitPrice * 0.5))); 
            }
        }
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