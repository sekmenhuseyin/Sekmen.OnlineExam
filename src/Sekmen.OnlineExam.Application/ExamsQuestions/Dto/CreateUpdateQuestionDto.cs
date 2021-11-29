using Abp.AutoMapper;
using Sekmen.OnlineExam.Exams;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sekmen.OnlineExam.ExamsQuestions.Dto
{
    [AutoMapFrom(typeof(Question))]
    public class CreateUpdateQuestionDto
    {
        [Required]
        public Guid ExamId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Order { get; set; }
    }
}
