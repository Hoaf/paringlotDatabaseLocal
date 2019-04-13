using PagedList;
using ParkinglotOnline.Areas.Host.Dao;
using ParkinglotOnline.Areas.Host.Dto;
using ParkinglotOnline.Areas.Host.MultipleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkinglotOnline.Areas.Host.Controllers
{
    public class HostController : Controller
    {
        // GET: Host/Host
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Details(string id)
        {
            Session["LotID"] = id;
            MultipleDetailpage model = new MultipleDetailpage();
            model.Detail =(IEnumerable<DetailDTO>) new DetailDAO().ListLotByHostID(id);
            if (model.Detail.Count<DetailDTO>()==0)
            {
                model.ListLot = new DetailDAO().ListLot(id);
            }
            return View(model);
        }
        public ActionResult List()
        {
           
            if (Session["hostID"]==null)
            {
                RedirectToAction("Login", "Index");
            }
            multipleHost model = new multipleHost();
            model.listLot = new ListLotDAO().ListLotByHostID(Session["hostID"].ToString());
            model.numberUnavailable = new NumberUnAvailableDAO().CountUnavailable(Session["hostID"].ToString());
            return View(model);
        }

        public ActionResult Cancel(FormCollection form)
        {
            try
            {
                string id = form["BillID"];
                DetailDAO dao = new DetailDAO();
                int cancel = dao.Cancel( Session["LotID"].ToString(), Session["hostID"].ToString(), int.Parse(id));
                if (cancel > 0)
                {
                    int available = dao.SetAvailable(Session["LotID"].ToString());
                    if (available>0)
                    {
                        return RedirectToAction("List", "Host", new { area = "Host" });
                    }
                }
                return RedirectToAction("List", "Host", new { area = "Host" });
            }
            catch
            {
                return RedirectToAction("List", "Host", new { area = "Host" });
            }
        }
                
    }
}