using PagedList;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.dao
{
    public class DriverDAO
    {
        ParkingLotOnlineEntities db = null;
        public Driver currentDriver { get; set; }

        public DriverDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
        //get full properties of driver
        public Driver GetCurrentDriver(String username)
        {
            var drv = from d in db.Drivers where d.Username.Equals(username) select d;
            return drv.SingleOrDefault();
        }

        public Driver AddNewUser(Driver driver) 
        {
            if(driver.PhoneNumber > 0)
            {
                try
                {
                    if (driverIsExisted(driver.Username))
                    {
                        driver.LoginErrorMessage = "Username or email have been used";
                    }
                    else
                    {
                        driver = db.Drivers.Add(driver);
                        db.SaveChanges();
                    }
                }
                catch (DbUpdateException)
                {
                    driver.LoginErrorMessage = "Username or email have been used";
                    return driver;
                }
                catch (DbEntityValidationException)
                {
                    driver.LoginErrorMessage = "Can't be blank any field";
                    return driver;
                }
            }
            else
            {
                driver.LoginErrorMessage = "Phone must be number";
            }
            return driver;
        }
        //DriverIsExisted In tbl_admin
        private bool driverIsExisted(String id)
        {
            if(db.Admins.Where(a=>a.ID == id).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
        public Driver getDriverById(String id)
        {
            return db.Drivers.FirstOrDefault(dr => dr.Username == id);
        }
        public void UpdateDriver(Driver driver)
        {
            db.Drivers.FirstOrDefault(dr => dr.Username == driver.Username).Fullname = driver.Fullname;
            db.Drivers.FirstOrDefault(dr => dr.Username == driver.Username).PhoneNumber = driver.PhoneNumber;
            db.SaveChanges();
        }

        public bool? ChangeStatus(String username)
        {
            bool? temp = db.Drivers.FirstOrDefault(dr => dr.Username == username).isEnable;
            db.Drivers.FirstOrDefault(dr => dr.Username == username).isEnable = !temp;
            db.SaveChanges();
            return !temp;
        }

        public IPagedList<ParkinglotOnline.Models.Driver> getListDriver(int page, int pageSize)
        {
            return db.Drivers.ToList().OrderBy(dr => dr.Fullname).ToPagedList(page, pageSize);
        }
        public IPagedList<ParkinglotOnline.Models.Driver> SearchByNameOrId(String search,int page, int pageSize)
        {
            return db.Drivers.Where(dr => dr.Fullname.ToUpper().Contains(search.ToUpper()) || dr.Username.Equals(search)).ToList().OrderBy(dr => dr.Fullname).ToPagedList(page,pageSize);
        }
    }
}