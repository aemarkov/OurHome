using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurHome.Web.Controllers
{
    /// <summary>
    /// Полезная информация
    /// </summary>
    [AllowAnonymous]
    public class InfoController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post(int id)
        {
            return View();
        }
    }
}