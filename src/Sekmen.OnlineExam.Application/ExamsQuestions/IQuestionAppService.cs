using Abp.Application.Services;
using Sekmen.OnlineExam.ExamsQuestions.Dto;
using System;

namespace Sekmen.OnlineExam.ExamsQuestions
{
    public interface IQuestionAppService : ICrudAppService<QuestionDto, Guid, PagedQuestionResultRequestDto, CreateUpdateQuestionDto, QuestionDto>
    {
    }
}
