using AutoMapper;

namespace Sekmen.OnlineExam.Exams.Dto
{
    public class ExamMapProfile : Profile
    {
        public ExamMapProfile()
        {
            CreateMap<ExamDto, Exam>();
            CreateMap<CreateUpdateExamDto, Exam>();
        }
    }
}
