using Abp.Application.Services;
using Sekmen.OnlineExam.Exams.Dto;
using System;

namespace Sekmen.OnlineExam.Exams
{
    public interface IExamAppService : ICrudAppService<ExamDto, Guid, PagedExamResultRequestDto, CreateUpdateExamDto, ExamDto>
    {
    }
}
