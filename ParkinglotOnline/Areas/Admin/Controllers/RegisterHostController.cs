using ParkinglotOnline.Areas.Admin.Models.Dao;
using ParkinglotOnline.Areas.Admin.Models.MultipleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkinglotOnline.Areas.Admin.Controllers
{
    public class RegisterHostController : Controller
    {
        // GET: Admin/RegisterHost
        public ActionResult Index()
        {
            
            MultipleAdmin model = new MultipleAdmin();
            model.cityId = model.SelectCity.ElementAt(0).Value;
            model.countyId = model.SelectCountyByCityId.ElementAt(0).Value;
            return View(model);
        }
        [HttpPost]
        public JsonResult ChooseCity(String cityId)
        {
            MultipleAdmin model = new MultipleAdmin();
            //assign cityId to search counties
            model.cityId = cityId;
            return this.Json(model.SelectCountyByCityId, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Register(MultipleAdmin model)
        {
            RegisterDAO dao = new RegisterDAO();
            string Confirm = Request.Form["txtConfirm"];
            if (model.host.Password==Confirm)
            {
                try
                {
                    int result = dao.RegisterHost(model.host.ID, model.host.Fullname, model.host.Address, model.host.Password, model.countyId);
                    if (result > 0)
                    {
                        ViewBag.Message = "Register successful!";
                        model.host.ID = "";
                        model.host.Fullname = "";
                        model.host.Address = "";
                        model.host.Password = "";
                    }
                    else
                    {
                        model.host.Password = "";
                        model.ErrorAcceptMessage = "Can't not register!";
                    }
                }
                catch (Exception)
                {
                    model.ErrorAcceptMessage = "Host ID has already existed!";
                    model.host.Password = "";
                }
            }
            else
            {
                model.ErrorAcceptMessage = "Confirm not match password!";
                model.host.Password = "";
            }
            
            model.cityId = model.SelectCity.ElementAt(0).Value;
            model.countyId = model.SelectCountyByCityId.ElementAt(0).Value;
            return View("Index",model);
        }
    }
}