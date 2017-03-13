using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurHome.Web.Areas.Admin.Controllers
{
    public class AdminDocumentsController : Controller
    {
        // GET: Admin/AdminDocuments
        public ActionResult Index()
        {
            ViewBag.AdminTitle = "Документы";
            return View("AdminDummy");
        }
    }
}