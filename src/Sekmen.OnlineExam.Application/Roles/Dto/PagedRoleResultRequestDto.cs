using Abp.Application.Services.Dto;

namespace Sekmen.OnlineExam.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

