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
    public class HostRequestController : Controller
    {
        // GET: Admin/HostRequest
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            MultipleAdmin model = new MultipleAdmin();
            IPagedList<HostRequestDTO> lists = (IPagedList<HostRequestDTO>)new HostRequestDAO().ListHostRequest(page, pageSize);
            model.CountHostRequest = new HostRequestDAO().CountHostRequest();
            model.ListHostRequest = lists;
            return View(model);
        }

        public ActionResult Accept(string id,int page = 1, int pageSize = 10)
        {
            MultipleAdmin model = new MultipleAdmin();
            HostRequestDAO dao = new HostRequestDAO();
            int accept = dao.AcceptRequest(id);
            if (accept <= 0 )
            {
                model.ErrorAcceptMessage = "Can't accept parking lot " + id;
            }
            else
            {
                model.ErrorAcceptMessage = "";
            }          
            IPagedList<HostRequestDTO> lists = (IPagedList<HostRequestDTO>)dao.ListHostRequest(page, pageSize);
            model.CountHostRequest = dao.CountHostRequest();
            model.ListHostRequest = lists;
            return View("Index",model);
        }

        public ActionResult Cancel(string id, int page = 1, int pageSize = 10)
        {
            MultipleAdmin model = new MultipleAdmin();
            HostRequestDAO dao = new HostRequestDAO();
            int cancel = dao.CancelRequest(id);
            if (cancel <= 0)
            {
                model.ErrorAcceptMessage = "Can't cancel parking lot " + id;
            }
            else
            {
                model.ErrorAcceptMessage = "";
            }
            IPagedList<HostRequestDTO> lists = (IPagedList<HostRequestDTO>)dao.ListHostRequest(page, pageSize);
            model.CountHostRequest = dao.CountHostRequest();
            model.ListHostRequest = lists;
            return View("Index", model);
        }
    }
}