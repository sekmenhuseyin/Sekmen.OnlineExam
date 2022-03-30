using Abp.AutoMapper;
using Sekmen.OnlineExam.Exams;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sekmen.OnlineExam.ExamsQuestionsAnswers.Dto
{
    [AutoMapTo(typeof(Answer))]
    public class CreateUpdateAnswerDto
    {
        [Required]
        public Guid QuestionId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsCorrect { get; set; }

        [Required]
        public int Order { get; set; }
    }
}
