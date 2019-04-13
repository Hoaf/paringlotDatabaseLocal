using PagedList;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ParkinglotOnline.Dto;

namespace ParkinglotOnline.dao
{
    public class DriverHistoryDAO
    {
        ParkingLotOnlineEntities db = null;
        //caculate total after loadHistory()
        public double totalPrice { get; set; }
        public DriverHistoryDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
        public IPagedList<DriverHistory> loadHistory(String driverId, int page, int pageSize)
        {
            object[] driver = new SqlParameter[]
            {
                new SqlParameter("@driverID",driverId),
            };
            var model = db.Database.SqlQuery<DriverHistory>("Sp_DriverBooked_History @driverID", driver).ToList().OrderByDescending(n => n.EntryDateTime);
            foreach (var item in model)
            {
                this.totalPrice += item.TotalPrice;
            }
            return model.ToPagedList(page, pageSize);
        }

    }
}