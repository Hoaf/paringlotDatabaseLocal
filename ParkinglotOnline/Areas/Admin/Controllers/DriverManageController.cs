using ParkinglotOnline.Areas.Admin.Models;
using ParkinglotOnline.Areas.Admin.Models.Dao;
using ParkinglotOnline.Areas.Admin.Models.MultipleModel;
using ParkinglotOnline.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkinglotOnline.Areas.Admin.Controllers
{
    public class DriverManageController : Controller
    {
        // GET: Admin/DriverManage
        public ActionResult Index(int page = 1, int pageSize = 4)
        {
            MultipleAdmin modelMulti = new MultipleAdmin();

            DriverManageModel model = new DriverManageModel();
            DriverDAO dao = new DriverDAO();
            if (Request.Form["txtSearch"] != null)
            {
                Session["lastSearch"] = Request.Form["txtSearch"];
                ViewData["lastSearch"] = Session["lastSearch"];
                if (Session["lastSearch"].ToString().Equals(""))
                {
                    model.ListDriver = dao.getListDriver(page, pageSize);
                    //after call another page
                    Session["lastSearch"] = null;
                }
                else
                {
                    model.ListDriver = dao.SearchByNameOrId(Session["lastSearch"].ToString(), page, pageSize);
                }
            }
            else if (Session["lastSearch"] != null)
            {
                ViewData["lastSearch"] = Session["lastSearch"];
                model.ListDriver = dao.SearchByNameOrId(Session["lastSearch"].ToString(), page, pageSize);
            }
            else
            {
                model.ListDriver = dao.getListDriver(page, pageSize);
            }
            modelMulti.Divermanager = model;
            modelMulti.CountHostRequest = new HostRequestDAO().CountHostRequest();

            return View(modelMulti);
        }

        public ActionResult ViewDetail(String username,int page = 1,int pageSize = 4)
        {
            // B/c pagelistPager can't pass parameters 
            if(username != null)
            {
                Session["DriverViewing"] = username;
            }
            DriverHistoryDAO dao = new DriverHistoryDAO();
            DriverManageModel model = new DriverManageModel();
            DriverDAO driverDAO = new DriverDAO();

            model.History = dao.loadHistory(Session["DriverViewing"].ToString(), page,pageSize);
            model.ListDriver = driverDAO.getListDriver(1, 4);
            model.DriverViewing = driverDAO.getDriverById(Session["DriverViewing"].ToString());
            ViewBag.TotalPrice = dao.totalPrice;

            //after view detail
            Session["lastSearch"] = null;

            MultipleAdmin modelMulti = new MultipleAdmin();
            modelMulti.Divermanager = model;
            return View("Index", modelMulti);
        }
        public ActionResult SaveEdition()
        {
            DriverDAO dao = new DriverDAO();
            String username = Request.Form["txtUsername"];
            try
            {
                int phonenumber = int.Parse(Request.Form["txtPhonenumber"]);
                String fullname = Request.Form["txtFullname"];
                if (fullname.Trim().Length != 0 && phonenumber > 0)
                {
                    ParkinglotOnline.Models.Driver driver = new ParkinglotOnline.Models.Driver
                    {
                        Username = username,
                        Fullname = fullname,
                        PhoneNumber = phonenumber,
                    };
                    dao.UpdateDriver(driver);
                    ViewBag.Status = "Update \"" + username + "\" successfully !!!";
                }
                else
                {
                    ViewBag.Status = "Phone must be number and can't be blank any field";
                }
            }
            catch (Exception)
            {
                ViewBag.Status = "Phone must be number and can't be blank any field";
            }
            //search after edit
            DriverManageModel model = new DriverManageModel();
            model.ListDriver = dao.SearchByNameOrId(username, 1, 4);
            ViewData["lastSearch"] = username;

            MultipleAdmin modelMulti = new MultipleAdmin();
            modelMulti.Divermanager = model;
            return View("Index", modelMulti);
        }
        [HttpPost]
        public JsonResult UpdateEnable(String username)
        {
            DriverDAO dao = new DriverDAO();
            bool? flag = dao.ChangeStatus(username);
            if (flag == true)
            {
                return this.Json(new { status = "true" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json(new { status = "false" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}