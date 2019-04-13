using PagedList;
using ParkinglotOnline.Areas.Admin.Models.Dao;
using ParkinglotOnline.Areas.Admin.Models.Dto;
using ParkinglotOnline.Areas.Admin.Models.MultipleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkinglotOnline.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            if (Session["adminID"] == null)
            {
                RedirectToAction("Login", "Index");
            }
            MultipleAdmin model = new MultipleAdmin();
            IPagedList<HostDTO> lists = (IPagedList<HostDTO>)new HostDAO().ListHost(page,pageSize);
            model.ListHost = lists;
            model.CountHostRequest = new HostRequestDAO().CountHostRequest();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(string id, int page = 1, int pageSize = 10)
        {
            if (Session["adminID"] == null)
            {
                RedirectToAction("Login", "Index");
            }
            Session["HostIDDetail"] = id;
            MultipleAdmin model = new MultipleAdmin();
            IPagedList<LotHostDTO> lists = (IPagedList<LotHostDTO>)new LotHostDAO().ListLotHost(Session["HostIDDetail"].ToString(), page, pageSize);
            model.ListLotHost = lists;
            model.CountHostRequest = new HostRequestDAO().CountHostRequest();
            model.Lot = new LotHostDAO().ListLot();
            return View(model);
        }

        public ActionResult EditHost(string id)
        {
            if (Session["adminID"] == null)
            {
                RedirectToAction("Login", "Index");
            }
            Session["DetailID"] = id;
            MultipleAdmin model = new MultipleAdmin();

            model.HostDetail = new HostDAO().HostDetail(id);

            model.CountHostRequest = new HostRequestDAO().CountHostRequest();

            model.cityId = model.SelectCity.ElementAt(0).Value;

            model.countyId = model.SelectCountyByCityId.ElementAt(0).Value;

            return View(model);
        }

        public ActionResult UpdateHost(MultipleAdmin model)
        {
            HostDAO dao = new HostDAO();
            int result = dao.UpdateHost( model.HostDetail.Fullname, model.HostDetail.Address, model.HostDetail.Password, model.countyId, model.HostDetail.ID);
            if (result > 0)
            {
                ViewBag.Message = "Update Success!";
            }
            else
            {
                model.ErrorAcceptMessage = "Can't Update!";
            }
            model.cityId = model.SelectCity.ElementAt(0).Value;
            model.countyId = model.SelectCountyByCityId.ElementAt(0).Value;
            return View("EditHost", model);
        }

        public ActionResult UnenableHost(string id)
        {
            HostDAO dao = new HostDAO();
            int result = dao.HostUnenable(id);
            MultipleAdmin model = new MultipleAdmin();
            if (result > 0)
            {
                ViewBag.Message = "Update Success!";
            }
            else
            {
                model.ErrorAcceptMessage = "Can't Update!";
            }
            model.HostDetail = new HostDAO().HostDetail(id);
            model.CountHostRequest = new HostRequestDAO().CountHostRequest();
            model.cityId = model.SelectCity.ElementAt(0).Value;
            model.countyId = model.SelectCountyByCityId.ElementAt(0).Value;
            return View("EditHost", model);
        }
        public ActionResult EnableHost(string id)
        {
            HostDAO dao = new HostDAO();
            int result = dao.HostEnable(id);
            MultipleAdmin model = new MultipleAdmin();
            if (result > 0)
            {
                ViewBag.Message = "Update Success!";
            }
            else
            {
                model.ErrorAcceptMessage = "Can't Update!";
            }
            model.HostDetail = new HostDAO().HostDetail(id);
            model.CountHostRequest = new HostRequestDAO().CountHostRequest();
            model.cityId = model.SelectCity.ElementAt(0).Value;
            model.countyId = model.SelectCountyByCityId.ElementAt(0).Value;
            return View("EditHost", model);
        }

        public ActionResult Update(int page = 1, int pageSize = 10)
        {
            string LotID = Request.Form["slRange"];
            string LoHID = Request.Form["txtLoHID"];
            MultipleAdmin model = new MultipleAdmin();
            LotHostDAO dao = new LotHostDAO();
            try
            {
                int result = dao.UpdateRangeLoH(LotID, LoHID);
                if (result <= 0)
                {
                    model.ErrorAcceptMessage = "Can't update parking lot " + LoHID;
                }
                else
                {
                    model.ErrorAcceptMessage = "";
                }
            }
            catch (Exception)
            {
                model.ErrorAcceptMessage = "New range of parking lot "+LoHID+" was not selected!";
            }
            IPagedList<LotHostDTO> lists = (IPagedList<LotHostDTO>)new LotHostDAO().ListLotHost(Session["HostIDDetail"].ToString(), page, pageSize);
            model.ListLotHost = lists;
            model.CountHostRequest = new HostRequestDAO().CountHostRequest();
            model.Lot = new LotHostDAO().ListLot();
            return View("Details",model);
        }

        public ActionResult AdminFinance(string id, int page = 1, int pageSize = 10)
        {
            Session["HostFinance"] = id;
            AdminFinanceDAO dao = new AdminFinanceDAO();
            Session["SlMonth"] = DateTime.Now.Month;
            Session["SlYear"] = DateTime.Now.Year;
            MultipleAdmin model = new MultipleAdmin();
            model.CountHostRequest = new HostRequestDAO().CountHostRequest();
            IPagedList<FinanceDTO> lists = (IPagedList<FinanceDTO>) dao.ListFinancialByMonthAndYear(Session["HostFinance"].ToString(),DateTime.Now.Month,DateTime.Now.Year ,page, pageSize);
            model.ListFinance = lists;
            model.Income = String.Format("{0:n}", dao.TotalIncome(@Session["HostFinance"].ToString(), DateTime.Now.Month, DateTime.Now.Year));
            return View(model);
        }
        public ActionResult FinanceDetail(int id)
        {
            Session["BillID"] = id;
            MultipleAdmin model = new MultipleAdmin();
            AdminFinanceDAO dao = new AdminFinanceDAO();
            model.SumPriceBill = String.Format("{0:n}", dao.TotalFinancial(Session["HostFinance"].ToString(), id, int.Parse(Session["SlMonth"].ToString()), int.Parse(Session["SlYear"].ToString())));
            model.ListFinanceDetail = dao.ListInfoEachLot(Session["HostFinance"].ToString(), id, int.Parse(Session["SlMonth"].ToString()), int.Parse(Session["SlYear"].ToString()));
            return View(model);
        }

        public ActionResult Search(int page = 1, int pageSize = 10)
        {
            int month = int.Parse(Request.Form["slMonth"]);
            int year = int.Parse(Request.Form["slYear"]);
            Session["SlMonth"] = month;
            Session["SlYear"] = year;
            MultipleAdmin model = new MultipleAdmin();
            AdminFinanceDAO dao = new AdminFinanceDAO();
            IPagedList<FinanceDTO> lists = (IPagedList<FinanceDTO>)dao.ListFinancialByMonthAndYear(Session["HostFinance"].ToString(), month, year, page, pageSize);
            model.ListFinance = lists;
            model.Income = String.Format("{0:n}", dao.TotalIncome(@Session["HostFinance"].ToString(), DateTime.Now.Month, DateTime.Now.Year));
            return View("AdminFinance", model);
        }

        public ActionResult RegisterHost()
        {
            return View();
        }
    }
}