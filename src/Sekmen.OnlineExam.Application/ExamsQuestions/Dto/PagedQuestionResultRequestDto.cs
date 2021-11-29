using Abp.Application.Services.Dto;
using System;

namespace Sekmen.OnlineExam.ExamsQuestions.Dto
{
    public class PagedQuestionResultRequestDto : PagedResultRequestDto
    {
        public Guid ExamId { get; set; }
    }
}
