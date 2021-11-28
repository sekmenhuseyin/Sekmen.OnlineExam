using Abp.Application.Services.Dto;

namespace Sekmen.OnlineExam.Exams.Dto
{
    public class PagedExamResultRequestDto : PagedResultRequestDto
    {
        public long UserId { get; set; }
    }
}
