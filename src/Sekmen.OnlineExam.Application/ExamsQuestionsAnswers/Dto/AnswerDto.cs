using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Sekmen.OnlineExam.Exams;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sekmen.OnlineExam.ExamsQuestionsAnswers.Dto
{
    [AutoMapFrom(typeof(Answer))]
    public class AnswerDto : AuditedEntityDto<Guid>
    {
        [Required]
        public string Name { get; set; }

        public bool IsCorrect { get; set; }

        [Required]
        public int Order { get; set; }
    }
}
