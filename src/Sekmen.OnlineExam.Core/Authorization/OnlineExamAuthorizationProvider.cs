using Abp.Authorization;
using Abp.Localization;

namespace Sekmen.OnlineExam.Authorization
{
    public class OnlineExamAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, OnlineExamConsts.LocalizationSourceName);
        }
    }
}
