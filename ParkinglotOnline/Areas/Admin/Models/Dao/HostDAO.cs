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
    public class HostDAO
    {
        ParkingLotOnlineEntities db = null;
        public HostDAO()
        {
            db = new ParkingLotOnlineEntities();
        }

        //Function get list bill by current month and year
        public IEnumerable<HostDTO> ListHost(int page, int pageSize)
        {
            var model = db.Database.SqlQuery<HostDTO>("Sp_Admin_ListHost");
            return model.ToList().ToPagedList(page, pageSize);
        }

        public HostDTO HostDetail(string HostID)
        {
            object[] Param = new SqlParameter[]
            {
                new SqlParameter("@HostID",HostID),
            };
            var model = db.Database.SqlQuery<HostDTO>("Sp_Admin_Host_Detail @HostID",Param).FirstOrDefault();
            return model;
        }
        public int UpdateHost( string FullName, string Address, string Password, string CountyID, string HostID)
        {
            object[] Param = new SqlParameter[]
            {
                new SqlParameter("@FullName",FullName),
                new SqlParameter("@Address",Address),
                new SqlParameter("@Password",Password),
                new SqlParameter("@CountyID",CountyID),
                new SqlParameter("@HostID",HostID)
            };
            var result = db.Database.ExecuteSqlCommand("Sp_Admin_Host_Update @FullName,@Address,@Password,@CountyID,@HostID", Param);
            return result;
        }
        public int HostUnenable(string HostID)
        {
            object[] Param = new SqlParameter[]
            {
                new SqlParameter("@HostID",HostID)
            };
            var result = db.Database.ExecuteSqlCommand("Sp_Admin_Host_UnEnable @HostID", Param);
            return result;
        }
        public int HostEnable(string HostID)
        {
            object[] Param = new SqlParameter[]
            {
                new SqlParameter("@HostID",HostID)
            };
            var result = db.Database.ExecuteSqlCommand("Sp_Admin_Host_Enable @HostID", Param);
            return result;
        }

        public List<ParkinglotOnline.Models.Host> searchResult(String countyId)
        {
            List<ParkinglotOnline.Models.Host> result = new List<ParkinglotOnline.Models.Host>();
            if (countyId != null)
            {
                foreach (var item in db.Hosts.ToList())
                {
                    if (item.CountyID.ToUpper().Equals(countyId.ToUpper()))
                    {
                        result.Add(item);
                    }
                }
            }
            if (result.Count() == 0)
            {
                result.Add(new ParkinglotOnline.Models.Host
                {
                    Address = "No host in this county"
                });
            }
            return result;
        }
        public ParkinglotOnline.Models.Host getHostById(String hostId)
        {
            return db.Hosts.Where(m => m.ID == hostId).FirstOrDefault();
        }
    }
}