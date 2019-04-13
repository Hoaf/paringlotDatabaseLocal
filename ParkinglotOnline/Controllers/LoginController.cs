using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkinglotOnline.Models;

namespace ParkinglotOnline.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            //Session.Abandon();
            return View();
        }
        public ActionResult SignUpSuccess(Driver driverModel)
        {
            driverModel.LoginErrorMessage = "Successfully !!";
            return View("Index",driverModel);
        }
        [HttpPost]
        public ActionResult Autherize(ParkinglotOnline.Models.Driver driverModel, ParkinglotOnline.Models.Host hostModel)
        {
            if(driverModel.Username != null && driverModel.Password != null)
            {
                using (ParkingLotOnlineEntities db = new ParkingLotOnlineEntities())
                {
                    object[] driverParam = new SqlParameter[]
                    {
                    new SqlParameter("@ID",driverModel.Username),
                    new SqlParameter("@Password",driverModel.Password)
                    };
                    object[] hostParam = new SqlParameter[]
                    {
                    new SqlParameter("@ID",driverModel.Username),
                    new SqlParameter("@Password",driverModel.Password)
                    };
                    var driverDetail = db.Database.SqlQuery<string>("Sp_Driver_Login @ID,@Password", driverParam).FirstOrDefault();
                    var hostDetail = db.Database.SqlQuery<string>("Sp_Host_Login @ID,@Password", hostParam).FirstOrDefault();
                    var adminDetail = db.Admins.Where(ad => ad.ID == driverModel.Username && ad.Password == driverModel.Password).FirstOrDefault();
                    if (driverDetail == null && hostDetail == null && adminDetail == null)
                    {
                        driverModel.LoginErrorMessage = "Invalid username or password!";
                        return View("Index", driverModel);
                    }
                    else if (driverDetail != null && hostDetail == null && adminDetail == null)
                    {
                        Session["driverName"] = driverDetail;
                        Session["driverID"] = driverModel.Username;
                        if (Session["LotId"] != null && Session["HostId"] != null)
                        {
                            return RedirectToAction("ViewHost", "Home");
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else if (driverDetail == null && hostDetail != null && adminDetail == null)
                    {
                        Session["hostID"] = driverModel.Username;
                        Session["hostName"] = hostDetail.ToString();
                        return RedirectToAction("List", "Host",new { area = "Host" });
                    }
                    else if (driverDetail == null && hostDetail == null && adminDetail != null)
                    {
                        Session["adminName"] = adminDetail.Name;
                        return RedirectToAction("Index", "DriverManage", new { area = "Admin" });
                    }
                }
            }
            return View("Index", driverModel);
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}