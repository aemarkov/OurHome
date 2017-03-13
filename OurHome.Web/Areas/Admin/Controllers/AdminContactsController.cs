using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurHome.Web.Areas.Admin.Controllers
{
    public class AdminContactsController : Controller
    {
        // GET: Admin/AdminContacts
        public ActionResult Index()
        {
            ViewBag.AdminTitle = "Контакты";
            return View("AdminDummy");
        }
    }
}