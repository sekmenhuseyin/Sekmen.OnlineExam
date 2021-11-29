using Abp.Application.Services.Dto;

namespace Sekmen.OnlineExam.Exams.Dto
{
    public class PagedExamResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public long UserId { get; set; }
    }
}
