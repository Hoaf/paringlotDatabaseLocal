using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.dao
{
    public class BookinglotDAO
    {
        ParkingLotOnlineEntities db = null;

        public BookinglotDAO()
        {
            db = new ParkingLotOnlineEntities();
        }
        //ID auto incre and this method return BookingLot which already added
        public BookingLot AddNewBookingLot(String driverId,DateTime entryTime)
        {
            BookingLot dto = new BookingLot {
                DriverID = driverId,
                EntryDateTime = entryTime,
            };
            dto = db.BookingLots.Add(dto);
            db.SaveChanges();
            return dto;
        }
        public void UpdateExitTime(int blId)
        {
            db.BookingLots.Where(bl => bl.ID == blId).FirstOrDefault().ExitDateTime = DateTime.Now;
            db.SaveChanges();
        }
        public BookingLot GetBookingLotById(int blId)
        {
            return db.BookingLots.Where(bl => bl.ID == blId).FirstOrDefault();
        }
    }
}