using PagedList;
using ParkinglotOnline.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Models
{
    public class BookingModel
    {
        public IPagedList<DriverHistory> driverHistory { get; set; }

        ParkingLotOnlineEntities db = null;
        public BookingModel()
        {
            db = new ParkingLotOnlineEntities();
        }
    }
}