using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurHome.Web.Areas.Admin.Controllers
{
    public class AdminSensorsController : Controller
    {
        // GET: Admin/AdminSensors
        public ActionResult Index()
        {
            ViewBag.AdminTitle = "Счетчики";
            return View("AdminDummy");
        }
    }
}