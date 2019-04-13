using PagedList;
using ParkinglotOnline.Areas.Host.Dao;
using ParkinglotOnline.dao;
using ParkinglotOnline.Dto;
using ParkinglotOnline.Models;
using ParkinglotOnline.Models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkinglotOnline.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();
            //set city & county dropdown list to Default
            model.cityId = model.SelectCity.ElementAt(0).Value;
            model.countyId = model.SelectCountyByCityId.ElementAt(0).Value;

            return View(model);
        }

        public ActionResult ViewHost(HomeModel model, int page = 1, int pageSize = 4)
        {
            //set city & county dropdown list to Default when PagedListPager
            if (model.countyId == null)
            {
                model.cityId = model.SelectCity.ElementAt(0).Value;
                model.countyId = model.SelectCountyByCityId.ElementAt(0).Value;
            }
            //avoiding model.hostId = null (at begin)
            if (Session["HostId"] == null && model.hostId != null)
            {
                Session["HostId"] = model.hostId;
                Session["LotId"] = model.lotId;
                IPagedList<ListLotDriver> lists = (IPagedList<ListLotDriver>)new ListlotDAO().ListLotByHostID(Session["HostId"].ToString(), Session["LotId"].ToString(), page, pageSize);
                model.listLot = lists;
            }
            else if(Session["HostId"] != null && Session["LotId"] != null)
            {
                IPagedList<ListLotDriver> lists = (IPagedList<ListLotDriver>)new ListlotDAO().ListLotByHostID(Session["HostId"].ToString(), Session["LotId"].ToString(), page, pageSize);
                model.listLot = lists;
            }
            setViewBagHostInfo();
            return View("Index", model);
        }

        //show host info
        private void setViewBagHostInfo()
        {
            if(Session["HostId"] != null)
            {
                HostDAO dao = new HostDAO();
                Host host = dao.getHostById(Session["HostId"].ToString());
                if (host != null)
                {
                    ViewBag.Address = host.Address;
                    ViewBag.FullName = host.Fullname;
                }
            }
            if (Session["LotId"] != null)
            {
                Lot lot = new LotDAO().getLotById(Session["LotId"].ToString());
                if (lot != null)
                {
                    ViewBag.LotName = lot.Name;
                }
                else
                {
                    ViewBag.LotName = "All";
                }
            }
        }

        [HttpPost]
        public JsonResult ChangeLotHost(String lothostId)
        {
            String[] lothost = lothostId.Split(':');
            Session["LotId"] = lothost[0];
            Session["HostId"] = lothost[1];
            return Json(lothostId, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChooseCity(String cityId)
        {
            HomeModel model = new HomeModel();
            //assign cityId to search counties
            model.cityId = cityId;
            return this.Json(model.SelectCountyByCityId, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getHost(String countyLotId)
        {
            String[] countyLot = countyLotId.Split(':');
            HomeModel model = new HomeModel();
            //assign countyId to search hosts
            model.countyId = countyLot[0];
            //update session when research
            if (model.searchHostResult.Count() > 0)
            {
                Session["HostId"] = model.searchHostResult.ElementAt(0).Value;
                Session["LotId"] = countyLot[1];
            }
            
            return this.Json(model.searchHostResult, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public JsonResult KeepSessionAlive()
        //{
        //    return  this.Json( new { Data = "Success" }, JsonRequestBehavior.AllowGet);
        //}

    }
}