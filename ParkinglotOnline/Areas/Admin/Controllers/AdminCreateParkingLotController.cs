using ParkinglotOnline.Areas.Admin.Models.Dao;
using ParkinglotOnline.Areas.Admin.Models.MultipleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkinglotOnline.Areas.Admin.Controllers
{
    public class AdminCreateParkingLotController : Controller
    {
        // GET: Admin/AdminCreateParkingLot
        public ActionResult Index()
        {
            return View();
        }
      
        [HttpGet]
        public ActionResult Create()
        {
            MultipleAdmin model = new MultipleAdmin();
            model.Lot = new LotHostDAO().ListLot();
            return View(model);

        }

        // POST: Admin/AdminCreateParkingLot/Create
        [HttpPost]
        public ActionResult Create(MultipleAdmin model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    string LotID = Request.Form["SLRange"];
                    LotHostDAO dao = new LotHostDAO();
                    int result = dao.Create(model.LotHostInsert.LoHID, model.LotHostInsert.HostID, LotID);
                    if (result > 0)
                    {
                        Session["SUCCESS"] = "Create Parking Lot";
                        return RedirectToAction("Create", "AdminCreateParkingLot", new { area = "Admin" });
                    }
                }
                Session["SUCCESS"] = null;
                model.ErrorAcceptMessage = "Can't create new parking lot!";
                model.Lot = new LotHostDAO().ListLot();
                return View(model);
            }
            catch
            {
                Session["SUCCESS"] = null;
                model.ErrorAcceptMessage = "Host ID is not existed or LoHID is existed!";
                model.Lot = new LotHostDAO().ListLot();
                return View(model);
            }
        }

       
    }
}
