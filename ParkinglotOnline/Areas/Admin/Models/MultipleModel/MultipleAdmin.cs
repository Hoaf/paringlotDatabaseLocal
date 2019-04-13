using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkinglotOnline.Areas.Admin.Models.Dto;
using ParkinglotOnline.Models;
using ParkinglotOnline.Areas.Admin.Models.Dao;
using System.Web.Mvc;

namespace ParkinglotOnline.Areas.Admin.Models.MultipleModel
{
    public class MultipleAdmin
    {
        public IPagedList<HostDTO> ListHost { get; set; }
        public IPagedList<LotHostDTO> ListLotHost { get; set; }
        public IPagedList<HostRequestDTO> ListHostRequest { get; set; }
        public string ErrorAcceptMessage { get; set; }
        public int CountHostRequest { get; set; }
        public HostDTO HostDetail { get; set; }
        public List<Lot> Lot { get; set; }
        public IPagedList<FinanceDTO> ListFinance { get; set; }
        public string SumPriceBill { get; set; }
        public string Income { get; set; }
        public IEnumerable<FinanceDetailDTO> ListFinanceDetail { get; set; }
        public ParkinglotOnline.Models.Host host { get; set; }

        public LotHost LotHostInsert { get; set; }

        public List<City> Cities { get; set; }
        public String cityId { get; set; }
        public String countyId { get; set; }
        public IEnumerable<SelectListItem> SelectCity
        {
            get
            {
                RegisterDAO dao = new RegisterDAO();
                Cities = dao.ListCity();
                return new SelectList(Cities, "ID", "Name");
            }
        }
        public IEnumerable<SelectListItem> SelectCountyByCityId
        {
            get
            {
                RegisterDAO dao = new RegisterDAO();
                dao.cityId = cityId;
                return new SelectList(dao.searchCounties(), "ID", "Name");
            }
        }
        public DriverManageModel Divermanager { get; set; }
    }
}