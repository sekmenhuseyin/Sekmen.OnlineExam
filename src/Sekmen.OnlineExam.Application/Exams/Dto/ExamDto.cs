using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sekmen.OnlineExam.Exams.Dto
{
    [AutoMapFrom(typeof(Exam))]
    public class ExamDto : AuditedEntityDto<Guid>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int Duration { get; set; }

        public bool IsActive { get; set; }

        public int QuestionCount { get; set; }
    }
}
