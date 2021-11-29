using Abp.Application.Services;
using Sekmen.OnlineExam.ExamsQuestionsAnswers.Dto;
using System;

namespace Sekmen.OnlineExam.ExamsQuestionsAnswers
{
    public interface IAnswerAppService : ICrudAppService<AnswerDto, Guid, PagedAnswerResultRequestDto, CreateUpdateAnswerDto, AnswerDto>
    {
    }
}
