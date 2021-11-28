using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Sekmen.OnlineExam.Exams.Dto
{
    [AutoMapTo(typeof(Exam))]
    public class CreateUpdateExamDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        public bool IsActive { get; set; }
    }
}
