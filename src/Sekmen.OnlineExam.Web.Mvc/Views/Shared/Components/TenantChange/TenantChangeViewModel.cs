using Abp.AutoMapper;
using Sekmen.OnlineExam.Sessions.Dto;

namespace Sekmen.OnlineExam.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
