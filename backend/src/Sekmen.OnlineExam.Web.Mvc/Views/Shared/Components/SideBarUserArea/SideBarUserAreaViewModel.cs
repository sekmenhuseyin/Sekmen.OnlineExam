using Sekmen.OnlineExam.Sessions.Dto;

namespace Sekmen.OnlineExam.Web.Views.Shared.Components.SideBarUserArea
{
    public class SideBarUserAreaViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformation { get; set; }

        public string GetShownLoginName()
        {
            var userName = LoginInformation.User?.UserName;

            return userName;
        }
    }
}
