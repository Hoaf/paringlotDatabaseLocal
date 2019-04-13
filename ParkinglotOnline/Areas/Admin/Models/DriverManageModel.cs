using PagedList;
using ParkinglotOnline.Models;
using ParkinglotOnline.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Admin.Models
{
    public class DriverManageModel
    {
        private ParkingLotOnlineEntities db = null;
        public IPagedList<ParkinglotOnline.Models.Driver> ListDriver { get; set; }
        public IPagedList<DriverHistory> History { get; set; }
        public ParkinglotOnline.Models.Driver DriverViewing { get; set; }

        public DriverManageModel()
        {
            db = new ParkingLotOnlineEntities();
        }
        public List<ParkinglotOnline.Models.Driver> getListDriver
        {
            get
            {
                return db.Drivers.ToList();
            }
        }
    }
}