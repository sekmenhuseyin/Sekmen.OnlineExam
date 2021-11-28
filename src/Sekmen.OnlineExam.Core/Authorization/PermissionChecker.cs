using Abp.Authorization;
using Sekmen.OnlineExam.Authorization.Roles;
using Sekmen.OnlineExam.Authorization.Users;

namespace Sekmen.OnlineExam.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
