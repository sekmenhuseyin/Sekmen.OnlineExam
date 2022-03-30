using Abp.Application.Services.Dto;

namespace Sekmen.OnlineExam.Exams.Dto
{
    public class PagedExamResultRequestDto : PagedResultRequestDto
    {
        public PagedExamResultRequestDto()
        {
            MaxResultCount = 20;
            SkipCount = 0;
        }

        public string Keyword { get; set; }
        public long UserId { get; set; }
    }
}
