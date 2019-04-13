using PagedList;
using ParkinglotOnline.Areas.Host.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.Models.MultipleModel
{
    public class MultipleFinancial
    {
        public IPagedList<FinancialCurrentDTO> Current { get; set; }
        public IEnumerable<FinancialInfoEachDTO> Each { get; set; }
        public string Total { get; set; }
        public string Income { get; set; }
    }
}