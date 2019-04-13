using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.MultipleModel
{
    public class MultipleCreatePage
    {
        public List<Lot> ListLot { get; set; }
        public LotHost LotHostInsert { get; set; }
        public string CreateErrorMessage { get; set; }
    }
}