using PagedList;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Host.Dao
{
    public class LotDAO
    {
        ParkingLotOnlineEntities db = null;
        public IPagedList<Dto.ListLot> listLot { get; set; }

        public LotDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
        public List<Lot> ListLot()
        {
            var list = db.Lots.ToList();
            return list;
        }

        public Lot getLotById(String LoHID)
        {
            return db.Lots.Where(l => l.ID == LoHID).FirstOrDefault();
        }
    }
}