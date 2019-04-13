using ParkinglotOnline.Models;
using ParkinglotOnline.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkinglotOnline.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            Session.Abandon();
            return View();
        }


        public ActionResult SignUp(Driver driver)
        {
            DriverDAO dao = new DriverDAO();
            driver.isEnable = true;
            driver = dao.AddNewUser(driver);
            if (driver.LoginErrorMessage != null)
            {
                return View("Index", driver);
            }

            return RedirectToAction("SignUpSuccess", "Login", driver);
        }
    }
}