using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using Sekmen.OnlineExam.Authorization;

namespace Sekmen.OnlineExam.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class OnlineExamNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(new MenuItemDefinition(PageNames.Home, L("HomePage"), url: "", icon: "fas fa-home", requiresAuthentication: true))
                .AddItem(new MenuItemDefinition(PageNames.Users, L("Users"), url: "Users", icon: "fas fa-users", permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)))
                .AddItem(new MenuItemDefinition(PageNames.Roles, L("Roles"), url: "Roles", icon: "fas fa-theater-masks", permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)))
                .AddItem(new MenuItemDefinition(PageNames.Exams, L("Exams"), url: "Exams", icon: "fas fa-file-alt"))
                .AddItem(new MenuItemDefinition(PageNames.About, L("About"), url: "About", icon: "fas fa-info-circle"))
                ;
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, OnlineExamConsts.LocalizationSourceName);
        }
    }
}