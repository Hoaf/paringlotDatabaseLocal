using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.dao
{
    public class BookingLotDetailDAO
    {
        ParkingLotOnlineEntities db = null;

        public BookingLotDetailDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
        public BookingLotDetail AddNewBookingLotDetail(String hostId,String lotId,int blId,double price,int status)
        {
            BookingLotDetail dto = new BookingLotDetail
            {
                HostID = hostId,
                LotID = lotId,
                BookingLotID = blId,
                UnitPrice = price,
                status = status,
            };
            dto = db.BookingLotDetails.Add(dto);
            db.SaveChanges();
            return dto;
        }
        public void updateStatus(int bldId,int status)
        {
            db.BookingLotDetails.Where(bld => bld.BLDId == bldId).FirstOrDefault().status = status;
            db.SaveChanges();
        }
        
        public void updateTotalPrice(int bldId,DateTime entry,double unitPrice)
        {
            TimeSpan total = this.totalTime(entry, DateTime.Now);
            double totalPrice=0;
            if (total.TotalHours <= 1)
            {
                totalPrice = unitPrice;
            }
            else
            {
                totalPrice = Math.Round(unitPrice + (total.TotalHours - 1) * (unitPrice * 0.5));
            }
            db.BookingLotDetails.Where(bld => bld.BLDId == bldId).FirstOrDefault().UnitPrice = totalPrice;
            db.SaveChanges();
        }


        private TimeSpan totalTime(DateTime entry,DateTime exit)
        {
          return (exit - entry);
        }
        
    }
}