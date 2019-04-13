using PagedList;
using ParkinglotOnline.Areas.Host.Dao;
using ParkinglotOnline.dao;
using ParkinglotOnline.Dto;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ParkinglotOnline.Models
{
    public class HomeModel
    {
        ParkingLotOnlineEntities db = null;

        public List<County> counties { get; set; }
        public List<City> cities { get; set; }
        public List<Lot> lots { get; set; }
        public List<Host> hosts { get; set; }
        public IPagedList<ListLotDriver> listLot { get; set; }
        public ListLotDriver bookedLot { get; set; }
        
        public String cityId { get; set; }
        public String countyId { get; set; }
        public String lotId { get; set; }
        public String hostId { get; set; }

        public HomeModel()
        {
            db = new ParkingLotOnlineEntities();
        }

        public IEnumerable<SelectListItem> SelectCity
        {
            get
            {
                CityDAO dao = new CityDAO();
                cities = dao.ListCity();
                return new SelectList(cities, "ID", "Name");
            }
        }
        public IEnumerable<SelectListItem> SelectCountyByCityId
        {
            get
            {
                CountyDAO dao = new CountyDAO();
                dao.cityId = cityId;
                return new SelectList(dao.searchCounties(), "ID", "Name");
            }
        }
        public IEnumerable<SelectListItem> SelectLot
        {
            get
            {
                LotDAO dao = new LotDAO();
                lots = dao.ListLot();
                lots.Add(new Lot
                {
                    ID = "All",
                    Name = "All"
                });
                return new SelectList(lots,"ID","Name");
            }
        }

        public IEnumerable<SelectListItem> searchHostResult
        {
            get
            {
                HostDAO dao = new HostDAO();
                return new SelectList(dao.searchResult(countyId), "ID", "Address");
            }
        }

    }

}