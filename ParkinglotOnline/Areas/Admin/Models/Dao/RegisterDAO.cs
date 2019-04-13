using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Admin.Models.Dao
{
    public class RegisterDAO
    {
        ParkingLotOnlineEntities db = null;
        public String cityId { get; set; }
        public String countyId { get; set; }
        public RegisterDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
        public List<City> ListCity()
        {
            var model = db.Cities.ToList();
            return model;
        }

        public List<County> ListCounty()
        {
            return db.Counties.ToList();
        }

        public List<County> searchCounties()
        {
            List<County> result = new List<County>();

            foreach (var item in db.Counties)
            {
                if (item.CityID.Equals(cityId))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public int RegisterHost(string HostID, string FullName,string Address, string Password, string CountyID)
        {
            object[] Param = new SqlParameter[]
            {
                new SqlParameter("@HostID",HostID),
                new SqlParameter("@FullName",FullName),
                new SqlParameter("@Address",Address),
                new SqlParameter("@Password",Password),
                new SqlParameter("@CountyID",CountyID),
            };
            var result = db.Database.ExecuteSqlCommand("Sp_Admin_Host_Register @HostID,@FullName,@Address,@Password,@CountyID", Param);
            return result;
        }
    }
}