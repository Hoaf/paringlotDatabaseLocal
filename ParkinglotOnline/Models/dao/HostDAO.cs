using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkinglotOnline.dao
{
    public class HostDAO
    {
        ParkingLotOnlineEntities db = null;

        public HostDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
        
        
        public List<Host> searchResult(String countyId)
        {
            List<Host> result = new List<Host>();
            if(countyId != null) { 
                foreach (var item in db.Hosts.ToList())
                {
                    if (item.CountyID.ToUpper().Equals(countyId.ToUpper()))
                    {
                        result.Add(item);
                    }
                }
            }
            if(result.Count() == 0)
            {
                result.Add(new Host {
                    Address = "No host in this county"
                });
            }
            return result;
        }
        public Host getHostById(String hostId)
        {
            return db.Hosts.Where(m => m.ID == hostId).FirstOrDefault();
        }
    }
}