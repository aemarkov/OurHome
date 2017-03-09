using Abp.Authorization;
using OurHome.Authorization.Roles;
using OurHome.MultiTenancy;
using OurHome.Users;

namespace OurHome.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
