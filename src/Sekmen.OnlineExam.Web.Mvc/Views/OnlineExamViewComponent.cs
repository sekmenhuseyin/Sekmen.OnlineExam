using Abp.AspNetCore.Mvc.ViewComponents;

namespace Sekmen.OnlineExam.Web.Views
{
    public abstract class OnlineExamViewComponent : AbpViewComponent
    {
        protected OnlineExamViewComponent()
        {
            LocalizationSourceName = OnlineExamConsts.LocalizationSourceName;
        }
    }
}
