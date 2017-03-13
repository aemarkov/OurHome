using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Authorization;
using Abp.Authorization.Users;
using OurHome.Users;

namespace OurHome.Web.Controllers
{
    public class TestController : OurHomeControllerBase
    {
        private readonly UserManager _userManager;

        public TestController(UserManager userManager)
        {
            _userManager = userManager;
        }


        // GET: Test
        public async Task<JsonResult> Roles()
        {
            var info = new UserInfo();

            info.UserId = AbpSession.UserId;
            info.TenantId = AbpSession.TenantId;

            if (info.UserId != null)
            {
                info.User = await _userManager.GetUserByIdAsync(info.UserId.Value);
                info.Roles = await _userManager.GetRolesAsync(info.UserId.Value);
                info.Permission = await _userManager.GetGrantedPermissionsAsync(info.User);
            }

            return Json(info, JsonRequestBehavior.AllowGet);
        }
    }

    class UserInfo
    {
        public long? UserId { get; set; }
        public long? TenantId { get; set; }
        public User User { get; set; }
        public IList<string> Roles { get; set; }
        public IReadOnlyList<Permission> Permission { get; set; }
    }
}