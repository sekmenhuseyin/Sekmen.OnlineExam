using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Sekmen.OnlineExam.Controllers;

namespace Sekmen.OnlineExam.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : OnlineExamControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
