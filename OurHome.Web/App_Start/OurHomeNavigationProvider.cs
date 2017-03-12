using Abp.Application.Navigation;
using Abp.Localization;
using OurHome.Authorization;

namespace OurHome.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class OurHomeNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        L("HomePage"),
                        url: "",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, OurHomeConsts.LocalizationSourceName);
        }
    }
}
