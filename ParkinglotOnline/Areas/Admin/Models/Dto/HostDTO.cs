using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Admin.Models.Dto
{
    public class HostDTO
    {
        public string ID { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string CountyName { get; set; }
        public string CityName { get; set; }
        public string Password { get; set; }
        public bool isEnable { get; set; }
    }
}