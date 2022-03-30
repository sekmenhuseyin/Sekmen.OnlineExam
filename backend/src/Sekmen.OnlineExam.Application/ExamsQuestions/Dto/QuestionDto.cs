using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Sekmen.OnlineExam.Exams;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sekmen.OnlineExam.ExamsQuestions.Dto
{
    [AutoMapFrom(typeof(Question))]
    public class QuestionDto : AuditedEntityDto<Guid>
    {
        [Required]
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
