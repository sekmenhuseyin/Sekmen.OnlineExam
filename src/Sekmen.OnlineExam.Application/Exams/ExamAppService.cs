using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Sekmen.OnlineExam.Exams.Dto;
using System;
using System.Linq;

namespace Sekmen.OnlineExam.Exams
{
    public class ExamAppService : CrudAppService<Exam, ExamDto, Guid, PagedExamResultRequestDto, CreateUpdateExamDto, ExamDto>, IExamAppService
    {

        public ExamAppService(IRepository<Exam, Guid> repository) : base(repository)
        {
        }

        public override ExamDto Create(CreateUpdateExamDto input)
        {
            input.IsActive = true;
            return base.Create(input);
        }

        public override ExamDto Update(ExamDto input)
        {
            if (AbpSession.UserId < 3)
                return base.Update(input);

            var item = Repository.Get(input.Id);
            if (item.CreatorUserId == AbpSession.UserId)
                return base.Update(input);

            return input;
        }

        public override void Delete(EntityDto<Guid> input)
        {
            if (AbpSession.UserId < 3)
                base.Delete(input);

            var item = Repository.Get(input.Id);
            if (item.CreatorUserId == AbpSession.UserId)
                base.Delete(input);
        }

        protected override IQueryable<Exam> CreateFilteredQuery(PagedExamResultRequestDto input)
        {
            return Repository.GetAll().WhereIf(AbpSession.UserId > 2, m => m.CreatorUserId == AbpSession.UserId);
        }
    }
}
