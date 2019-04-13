using ParkinglotOnline.Areas.Host.Dto;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.Dao
{
    public class DetailDAO
    {
        ParkingLotOnlineEntities db = null;
        public DetailDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
        public IEnumerable<DetailDTO> ListLotByHostID(String LoHID)
        {
            object[] Param = new SqlParameter[]
            {
                new SqlParameter("@LoHID",LoHID),
            };
            var result = db.Database.SqlQuery<DetailDTO>("Sp_Infomation_Detail @LoHID", Param).ToList();

            return result;
        }
        public IEnumerable<Lot> ListLot(string id)
        {
            object[] Param = new SqlParameter[]
            {
                new SqlParameter("@LoHID",id),
            };
            var result = db.Database.SqlQuery<Lot>("Sp_Lot_ByLoHID @LoHID", Param).ToList();

            return result;
        }
        public int Cancel(string LoHID, string HostID, int BookingID)
        {
            object[] LotHostParam = new SqlParameter[]
            {
                new SqlParameter("@BookingLotID",BookingID),
                new SqlParameter("@LoHID",LoHID),
                new SqlParameter("@HostID",HostID),
            };
            var result = db.Database.ExecuteSqlCommand("Sp_BookingDetail_Cancel @BookingLotID,@LoHID,@HostID", LotHostParam);
            return result;
        }
        public int SetAvailable(string LoHID)
        {
            object[] LotHostParam = new SqlParameter[]
            {
                new SqlParameter("@LoHID",LoHID),
            };
            var result = db.Database.ExecuteSqlCommand("Sp_LotHost_Available @LoHID", LotHostParam);
            return result;
        }
    }
}