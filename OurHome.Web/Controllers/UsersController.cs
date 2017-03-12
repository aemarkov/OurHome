using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using OurHome.Authorization;
using OurHome.Users;

namespace OurHome.Web.Controllers
{
    //TODO: Понятия не имею, зачем UsersController
    /*[AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : OurHomeControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }*/
}