using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace OurHome.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : OurHomeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}