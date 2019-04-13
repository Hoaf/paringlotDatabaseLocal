using PagedList;
using ParkinglotOnline.Areas.Host.Models.Dao;
using ParkinglotOnline.Areas.Host.Models.Dto;
using ParkinglotOnline.Areas.Host.Models.MultipleModel;
using ParkinglotOnline.Areas.Host.MultipleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkinglotOnline.Areas.Host.Controllers
{
    public class FinanceController : Controller
    {
        // GET: Host/Finance
        public ActionResult Index(int page = 1, int pageSize = 4)
        {
            if (Session["hostID"] == null)
            {
                RedirectToAction("Login", "Index");
            }
            Session["SlMonth"] = DateTime.Now.Month;
            Session["SlYear"] = DateTime.Now.Year;
            MultipleFinancial model = new MultipleFinancial();
            IPagedList<FinancialCurrentDTO> lists = (IPagedList<FinancialCurrentDTO>)new FinancialDAO().ListFinancialCurrent(Session["hostID"].ToString(), page, pageSize);
            model.Current = lists;
            model.Income = String.Format("{0:n}", new FinancialDAO().TotalIncome(Session["hostID"].ToString(), DateTime.Now.Month, DateTime.Now.Year));
            return View(model);
        }

        // GET: Host/Finance/Details/5
        public ActionResult Details(int id)
        {

            Session["BillID"] = id;
            MultipleFinancial model = new MultipleFinancial();
            model.Total = String.Format("{0:n}", new FinancialDAO().TotalFinancial(Session["hostID"].ToString(), id, int.Parse(Session["SlMonth"].ToString()), int.Parse(Session["SlYear"].ToString())));
            model.Each = new FinancialDAO().ListInfoEachLot(Session["hostID"].ToString(), id, int.Parse(Session["SlMonth"].ToString()), int.Parse(Session["SlYear"].ToString()));
            return View(model);
        }

        public ActionResult Search(int page = 1, int pageSize = 4)
        {
            int month = int.Parse(Request.Form["slMonth"]);
            int year = int.Parse(Request.Form["slYear"]);
            Session["SlMonth"] = month;
            Session["SlYear"] = year;
            MultipleFinancial model = new MultipleFinancial();
            IPagedList<FinancialCurrentDTO> lists = (IPagedList<FinancialCurrentDTO>)new
                FinancialDAO().ListFinancialByMonthAndYear(Session["hostID"].ToString(), month, year, page, pageSize);
            model.Current = lists;
            model.Income = String.Format("{0:n}", new FinancialDAO().TotalIncome(Session["hostID"].ToString(), DateTime.Now.Month, DateTime.Now.Year));
            return View("Index", model);
        }
    }
}
