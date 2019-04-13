using PagedList;
using ParkinglotOnline.Areas.Host.Dao;
using ParkinglotOnline.dao;
using ParkinglotOnline.Dto;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkinglotOnline.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index(int page=1,int pageSize=4)
        {
            return View(InitialPage(page,pageSize));
        }
        public ActionResult Booked(int page = 1, int pageSize = 4)
        {
            if (Session["driverID"] != null)
            {
                String loHID = Request.Form["LOHID"];
                String driverId = Session["driverID"].ToString();
                DateTime entryTime = DateTime.Now;
                //Booking lotID auto inscre
                //tbl BookingDetail (BLDID auto incre)
                String hostID = Session["HostId"].ToString();
                String lotID = Session["LotId"].ToString();
                //double price = Double.Parse(Request.Form["PRICE"]);
                //Add to BookLot
                BookinglotDAO dao = new BookinglotDAO();
                //tbl BookingLot (Booking lot id auto incre)
                BookingLot newBL = dao.AddNewBookingLot(driverId, entryTime);
                //Add to bookingDetail
                BookingLotDetailDAO bldDao = new BookingLotDetailDAO();
                bldDao.AddNewBookingLotDetail(hostID, loHID, newBL.ID,0,1);
                //Update available
                Areas.Host.Dao.LotHostDAO lhDao = new Areas.Host.Dao.LotHostDAO();
                lhDao.updateAvailableLot(loHID, false); 
            }
            return View("Index", InitialPage(page,pageSize));
        }
        //InitialPage
        private BookingModel InitialPage(int page,int pageSize)
        {
            //remove search session
            Session["HostId"] = null;
            Session["LotId"] = null;

            IPagedList<DriverHistory> lists = new DriverHistoryDAO().loadHistory(Session["driverID"].ToString(), page, pageSize);
            BookingModel model = new BookingModel();
            model.driverHistory = lists;
            return model;
        }

        public ActionResult Checkout(int bldId,String loHID,int blId, int page = 1, int pageSize = 4)
        {
            BookingLotDetailDAO bldDao = new BookingLotDetailDAO();
            bldDao.updateStatus(bldId,3);//3 is paid

            Areas.Host.Dao.LotHostDAO lhDao = new Areas.Host.Dao.LotHostDAO(); // update available lot
            lhDao.updateAvailableLot(loHID, true);

            BookinglotDAO blDao = new BookinglotDAO();// update exitTime
            blDao.UpdateExitTime(blId);

            //Update totalPrice after calculate hours
            String lotId = lhDao.getLotHostById(loHID).LotID;
            double unitPrice = new LotDAO().getLotById(lotId).UnitPrice;
            BookingLot dto = blDao.GetBookingLotById(blId);
            bldDao.updateTotalPrice(bldId, dto.EntryDateTime, unitPrice);

            return View("Index",InitialPage(page,pageSize));
        }

        public ActionResult Cancel(int page = 1, int pageSize = 4)
        {
            String loHID = Request.Form["LoHID"];
            String bldId = Request.Form["BLDID"];
            
            BookingLotDetailDAO dao = new BookingLotDetailDAO();
            dao.updateStatus(int.Parse(bldId), 2);//2 is cancel

            Areas.Host.Dao.LotHostDAO lhDao = new Areas.Host.Dao.LotHostDAO(); // update available lot
            lhDao.updateAvailableLot(loHID, true);
            return View("Index", InitialPage(page, pageSize));
        }
    }
}