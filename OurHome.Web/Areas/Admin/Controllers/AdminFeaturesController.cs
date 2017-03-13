using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurHome.Web.Areas.Admin.Controllers
{
    public class AdminFeaturesController : Controller
    {
        // GET: Admin/AdminFeatures
        public ActionResult Index()
        {
            ViewBag.AdminTitle = "Особенности";
            return View("AdminDummy");
        }
    }
}