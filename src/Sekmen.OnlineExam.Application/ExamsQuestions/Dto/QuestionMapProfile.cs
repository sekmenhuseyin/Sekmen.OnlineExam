using AutoMapper;
using Sekmen.OnlineExam.Exams;

namespace Sekmen.OnlineExam.ExamsQuestions.Dto
{
    public class QuestionMapProfile : Profile
    {
        public QuestionMapProfile()
        {
            CreateMap<QuestionDto, Question>();
            CreateMap<CreateUpdateQuestionDto, Question>();
        }
    }
}
