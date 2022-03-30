using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Sekmen.OnlineExam.Web.Views
{
    public abstract class OnlineExamRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected OnlineExamRazorPage()
        {
            LocalizationSourceName = OnlineExamConsts.LocalizationSourceName;
        }
    }
}
