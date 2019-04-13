using ParkinglotOnline.Areas.Host.Dto;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.Dao
{
    public class NumberUnAvailableDAO
    {
        ParkingLotOnlineEntities db = null;
        public NumberUnAvailableDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
       
        public int CountUnavailable(string hostID)
        {
            NumberLotUnavailable dto = new NumberLotUnavailable();
            object[] host = new SqlParameter[]
                {
                    new SqlParameter("@ID",hostID),

                };
            return dto.Number = db.Database.SqlQuery<int>("Sp_Count_Parkinglot_unavailable @ID", host).FirstOrDefault();
        }
    }
}