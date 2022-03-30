using AutoMapper;
using Sekmen.OnlineExam.Exams;

namespace Sekmen.OnlineExam.ExamsQuestionsAnswers.Dto
{
    public class AnswerMapProfile : Profile
    {
        public AnswerMapProfile()
        {
            CreateMap<AnswerDto, Answer>();
            CreateMap<CreateUpdateAnswerDto, Answer>();
        }
    }
}
