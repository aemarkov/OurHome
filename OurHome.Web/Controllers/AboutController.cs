using System.Web.Mvc;

namespace OurHome.Web.Controllers
{
    public class AboutController : OurHomeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}