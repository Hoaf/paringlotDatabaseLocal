using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkinglotOnline.dao
{
    public class CountyDAO
    {
        ParkingLotOnlineEntities db = null;
        public String cityId { get; set; }
        public CountyDAO()
        {
            db = new ParkingLotOnlineEntities();
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
    }
}