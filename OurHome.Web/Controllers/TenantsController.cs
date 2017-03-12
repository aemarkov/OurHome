using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using OurHome.Authorization;
using OurHome.MultiTenancy;

namespace OurHome.Web.Controllers
{
    //TODO: Понятия не имею, зачем TenantsController
    /*[AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : OurHomeControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }*/
}