using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurHome.Web.Areas.Admin.Controllers
{
    public class AdminNewsController : Controller
    {
        // GET: Admin/AdminNews
        public ActionResult Index()
        {
            ViewBag.AdminTitle = "Новости";
            return View("AdminDummy");
        }
    }
}