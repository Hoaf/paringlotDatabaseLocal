using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.Dao
{
    public class LotHostDAO
    {
        ParkingLotOnlineEntities db = null;
        public LotHostDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
        public int Create(string LoHID, string HostID, string LotID)
        {
            object[] LotHostParam = new SqlParameter[]
            {
                new SqlParameter("@LoHID",LoHID),
                new SqlParameter("@HostID",HostID),
                new SqlParameter("@LotID",LotID),
            };
            var result = db.Database.ExecuteSqlCommand("Sp_LotHost_Insert @LoHID,@HostID,@LotID", LotHostParam);
            return result;
        }

        public int CountLotHot(string hostID)
        {
            object[] LotHostParam = new SqlParameter[]
            {
                new SqlParameter("@HostID",hostID),
            };
            int model = db.Database.SqlQuery<int>("Sp_LotHot_Count @HostID", LotHostParam).FirstOrDefault();
            return model;
        }
        public void updateAvailableLot(String LoHID, bool available)
        {
            db.LotHosts.Where(lh => lh.LoHID == LoHID).FirstOrDefault().Available = available;
            db.SaveChanges();
        }
        public LotHost getLotHostById(String id)
        {
            return db.LotHosts.Where(l => l.LoHID == id).FirstOrDefault();
        }
    }
}