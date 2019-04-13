using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ParkinglotOnline.dao
{
    public class CityDAO
    {
        
        ParkingLotOnlineEntities db = null;

        public CityDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
        public List<City> ListCity()
        {
            return db.Cities.ToList();
        }
        
    }
}