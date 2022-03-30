using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Sekmen.OnlineExam.Exams.Dto;
using System;
using System.Linq;

namespace Sekmen.OnlineExam.Exams
{
    [AbpAuthorize]
    public class ExamAppService : CrudAppService<Exam, ExamDto, Guid, PagedExamResultRequestDto, CreateUpdateExamDto, ExamDto>, IExamAppService
    {

        public ExamAppService(IRepository<Exam, Guid> repository) : base(repository)
        {
        }

        public override ExamDto Create(CreateUpdateExamDto input)
        {
            var entity = MapToEntity(input);
            entity.UpdateCreator(AbpSession.GetUserId());
            Repository.Insert(entity);
            CurrentUnitOfWork.SaveChanges();
            return MapToEntityDto(entity);
        }

        public override ExamDto Update(ExamDto input)
        {
            var item = Repository.Get(input.Id);
            if (item.CreatorUserId != AbpSession.UserId && AbpSession.UserId > 2)
                return input;

            var entityById = GetEntityById(input.Id);
            entityById.Update(input.Name, input.Description, input.Duration, input.IsActive, AbpSession.GetUserId());
            CurrentUnitOfWork.SaveChanges();
            return MapToEntityDto(entityById);
        }

        public override void Delete(EntityDto<Guid> input)
        {
            var item = Repository.Get(input.Id);
            if (item.CreatorUserId == AbpSession.UserId || AbpSession.UserId <= 2)
                base.Delete(input);
        }

        protected override IQueryable<Exam> CreateFilteredQuery(PagedExamResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), m => m.Name.Contains(input.Keyword))
                .WhereIf(AbpSession.UserId > 2, m => m.CreatorUserId == AbpSession.UserId);
        }
    }
}
