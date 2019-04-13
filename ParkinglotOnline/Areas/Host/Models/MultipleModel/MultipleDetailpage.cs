using ParkinglotOnline.Areas.Host.Dto;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.MultipleModel
{
    public class MultipleDetailpage
    {
        public IEnumerable<Lot> ListLot { get; set; }
        public IEnumerable<DetailDTO> Detail { get; set; }
        public string BillID { get; set; }
    }
}