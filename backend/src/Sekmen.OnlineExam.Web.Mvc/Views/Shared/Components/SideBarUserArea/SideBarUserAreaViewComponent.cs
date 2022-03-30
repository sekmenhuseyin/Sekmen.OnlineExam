using Microsoft.AspNetCore.Mvc;
using Sekmen.OnlineExam.Sessions;
using System.Threading.Tasks;

namespace Sekmen.OnlineExam.Web.Views.Shared.Components.SideBarUserArea
{
    public class SideBarUserAreaViewComponent : OnlineExamViewComponent
    {
        private readonly ISessionAppService _sessionAppService;

        public SideBarUserAreaViewComponent(ISessionAppService sessionAppService)
        {
            _sessionAppService = sessionAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new SideBarUserAreaViewModel
            {
                LoginInformation = await _sessionAppService.GetCurrentLoginInformations(),
            };

            return View(model);
        }
    }
}
