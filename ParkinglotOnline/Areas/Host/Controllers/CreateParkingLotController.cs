using ParkinglotOnline.Areas.Host.Dao;
using ParkinglotOnline.Areas.Host.MultipleModel;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkinglotOnline.Areas.Host.Controllers
{
    public class CreateParkingLotController : Controller
    {
        // GET: Host/CreateParkingLot
        public ActionResult Index()

        {
            return View();
        }

        // GET: Host/CreateParkingLot/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Host/CreateParkingLot/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["hostID"] == null)
            {
                RedirectToAction("Login", "Index");
            }
            MultipleCreatePage model = new MultipleCreatePage();
            List<Lot> lists = new LotDAO().ListLot();
            model.ListLot = lists;
            return View(model);
        }

        // POST: Host/CreateParkingLot/Create
        [HttpPost]
        public ActionResult Create(MultipleCreatePage model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    LotHostDAO dao = new LotHostDAO();
                    int count = dao.CountLotHot(Session["hostID"].ToString());
                    string LoHID = Session["hostID"].ToString().ToUpper()+"-"+count;
                    int result = dao.Create(LoHID, Session["hostID"].ToString(), model.LotHostInsert.LotID);
                    if (result>0)
                    {
                        Session["SUCCESS"] = "Create Parking Lot "+ LoHID+" Success!\n Waiting For Administration Accept!";
                        
                        return RedirectToAction("Create", "CreateParkingLot", new { area = "Host"});
                    }
                    else
                    {
                        
                        ModelState.AddModelError("", "Create new parking lot is false!");
                    }
                    
                }
                Session["SUCCESS"] = null;
                List<Lot> lists = new LotDAO().ListLot();
                model.ListLot = lists;
                return View(model);
            }
            catch
            {
                Session["SUCCESS"] = null;
                List<Lot> lists = new LotDAO().ListLot();
                model.ListLot = lists;
                model.CreateErrorMessage = "You must select range of parking lot!";
                return View(model);
            }
        }      
    }
}
