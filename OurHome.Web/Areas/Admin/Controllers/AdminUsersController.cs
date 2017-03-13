using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurHome.Web.Areas.Admin.Controllers
{
    public class AdminUsersController : Controller
    {
        // GET: Admin/AdminUsers
        public ActionResult Index()
        {
            ViewBag.AdminTitle = "Пользователи";
            return View("AdminDummy");
        }
    }
}