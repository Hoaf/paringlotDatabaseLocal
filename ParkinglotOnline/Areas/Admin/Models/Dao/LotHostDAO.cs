using PagedList;
using ParkinglotOnline.Areas.Admin.Models.Dto;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Admin.Models.Dao
{
    public class LotHostDAO
    {
        ParkingLotOnlineEntities db = null;
        public LotHostDAO()
        {
            db = new ParkingLotOnlineEntities();
        }

        public IEnumerable<LotHostDTO> ListLotHost(string hostID, int page, int pageSize)
        {
            object[] Param = new SqlParameter[]
            {
                new SqlParameter("@HostID",hostID),
            };
            var model = db.Database.SqlQuery<LotHostDTO>("Sp_Admin_ListLotHot @HostID", Param);
            return model.ToList().ToPagedList(page, pageSize);
        }
        public List<Lot> ListLot()
        {
            var list = db.Lots.ToList();
            return list;
        }
        public int UpdateRangeLoH(string LotID,string LoHID)
        {
            object[] Param = new SqlParameter[]
            {
                new SqlParameter("@LotID",LotID),
                new SqlParameter("@LoHID",LoHID),
            };
            var result = db.Database.ExecuteSqlCommand("Sp_Admin_LotHot_UpdateLoHID @LotID,@LoHID", Param);
            return result;
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