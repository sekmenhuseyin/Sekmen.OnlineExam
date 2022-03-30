using Abp.Application.Services.Dto;
using System;

namespace Sekmen.OnlineExam.ExamsQuestions.Dto
{
    public class PagedQuestionResultRequestDto : PagedResultRequestDto
    {
        public PagedQuestionResultRequestDto()
        {
            MaxResultCount = 20;
            SkipCount = 0;
        }

        public Guid ExamId { get; set; }
    }
}
