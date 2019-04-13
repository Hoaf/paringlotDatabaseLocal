using PagedList;
using ParkinglotOnline.Areas.Host.Dto;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.Dao
{
    public class ListLotDAO
    {
        ParkingLotOnlineEntities db = null;
        public ListLotDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
        public IEnumerable<ListLot> ListLotByHostID(String hostID)
        {
            object[] LotHostParam = new SqlParameter[]
            {
                new SqlParameter("@HostID",hostID),
            };
            var model = db.Database.SqlQuery<ListLot>("Sp_LotHost_Lot @HostID", LotHostParam);
            return model.ToList();
        }
    }
}