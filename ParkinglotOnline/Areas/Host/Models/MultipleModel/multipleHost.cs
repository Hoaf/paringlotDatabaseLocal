using PagedList;
using ParkinglotOnline.Areas.Host.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.MultipleModel
{
    public class multipleHost
    {
        public IEnumerable<ListLot> listLot { get; set; }
        public int numberUnavailable { get; set; }
    }
}