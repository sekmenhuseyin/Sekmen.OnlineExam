using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Sekmen.OnlineExam.Controllers
{
    public abstract class OnlineExamControllerBase: AbpController
    {
        protected OnlineExamControllerBase()
        {
            LocalizationSourceName = OnlineExamConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
