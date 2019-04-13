using ParkinglotOnline.Areas.Admin.Models.Dao;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Dto
{
    public class DriverHistory
    {
        public int BLDId { get; set; }
        public string Username { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime? ExitDateTime { get; set; }
        public string HostID { get; set; }
        public string statusName { get; set; }
        public string LoHID { get; set; }
        public double UnitPrice { get; set; }
        public string LotImage { get; set; }
        public int BLid { get; set; }
        public double TotalPrice { get; set; }

        public Host getHostById()
        {
            HostDAO dao = new HostDAO();
            return dao.getHostById(this.HostID);
        }
    }
}