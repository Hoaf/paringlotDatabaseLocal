using PagedList;
using ParkinglotOnline.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Models.dao
{
    public class ListlotDAO
    {
        ParkingLotOnlineEntities db = null;
        public ListlotDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
        public IEnumerable<ListLotDriver> ListLotByHostID(String hostID, String lotID, int page, int pageSize)
        {

            object[] LotHostParam = new SqlParameter[]
            {
                new SqlParameter("@HostID",hostID),
                new SqlParameter("@LotID",lotID),
            };
            var model = db.Database.SqlQuery<ListLotDriver>("Sp_LotHost_Lot_Driver @HostID,@LotID", LotHostParam);
            if (lotID.Equals("All"))
            {
                model = db.Database.SqlQuery<ListLotDriver>("Sp_LotHost_Lot_Driver_All @HostID", LotHostParam);
            }
            return model.ToList().ToPagedList(page, pageSize);
        }
    }
}