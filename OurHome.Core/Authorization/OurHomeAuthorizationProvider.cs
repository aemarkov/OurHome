using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace OurHome.Authorization
{
    public class OurHomeAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {            
            var pages = CreateIfNotExists(context, PermissionNames.Pages, L("Pages"));
            var admin = CreateIfNotExists(context, PermissionNames.Admininstration, L("Admininstration"));
            var user = CreateIfNotExists(context, PermissionNames.User, L("User"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, OurHomeConsts.LocalizationSourceName);
        }

        //Создает пермишен, если он не создан
        private static Permission CreateIfNotExists(IPermissionDefinitionContext context, string name, ILocalizableString displayName, Permission parent = null)
        {
            Permission permission;

            if (parent == null)
            {
                if ((permission = context.GetPermissionOrNull(name)) == null)
                    permission = context.CreatePermission(name, displayName);
            }
            else
            {
                if ((permission = context.GetPermissionOrNull(name)) == null)
                    permission = parent.CreateChildPermission(name, displayName);
            }

            return permission;
        }
    }
}
