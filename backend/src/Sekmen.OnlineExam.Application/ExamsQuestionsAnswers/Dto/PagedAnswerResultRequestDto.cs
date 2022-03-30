using Abp.Application.Services.Dto;
using System;

namespace Sekmen.OnlineExam.ExamsQuestionsAnswers.Dto
{
    public class PagedAnswerResultRequestDto : PagedResultRequestDto
    {
        public PagedAnswerResultRequestDto()
        {
            MaxResultCount = 20;
            SkipCount = 0;
        }

        public Guid QuestionId { get; set; }
    }
}
