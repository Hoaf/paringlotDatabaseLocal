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
    public class HostRequestDAO
    {
        ParkingLotOnlineEntities db = null;
        public HostRequestDAO()
        {
            db = new ParkingLotOnlineEntities();
        }

        //Function get list bill by current month and year
        public IEnumerable<HostRequestDTO> ListHostRequest(int page, int pageSize)
        {
            var model = db.Database.SqlQuery<HostRequestDTO>("Sp_Admin_Host_Request");
            return model.ToList().ToPagedList(page, pageSize);
        }

        public int AcceptRequest(string LoHID)
        {
            object[] Param = new SqlParameter[]
            {
                new SqlParameter("@LoHID",LoHID),
            };
            var result = db.Database.ExecuteSqlCommand("Sp_Admin_Host_AcceptRequest @LoHID", Param);
            return result;
        }

        public int CancelRequest(string LoHID)
        {
            object[] Param = new SqlParameter[]
            {
                new SqlParameter("@LoHID",LoHID),
            };
            var result = db.Database.ExecuteSqlCommand("Sp_Admin_Host_CancelRequest @LoHID", Param);
            return result;
        }

        public int CountHostRequest()
        {
            int model = db.Database.SqlQuery<int>("Sp_Admin_Host_CountNotific").FirstOrDefault();
            return model;
        }
    }
}