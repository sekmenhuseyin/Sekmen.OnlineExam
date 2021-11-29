using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Sekmen.OnlineExam.Exams;
using Sekmen.OnlineExam.ExamsQuestionsAnswers.Dto;
using System;
using System.Linq;

namespace Sekmen.OnlineExam.ExamsQuestionsAnswers
{
    public class AnswerAppService : CrudAppService<Answer, AnswerDto, Guid, PagedAnswerResultRequestDto, CreateUpdateAnswerDto, AnswerDto>, IAnswerAppService
    {
        private readonly IRepository<Question, Guid> _questionRepository;

        public AnswerAppService(IRepository<Answer, Guid> repository, IRepository<Question, Guid> questionRepository) : base(repository)
        {
            _questionRepository = questionRepository;
        }

        public override AnswerDto Create(CreateUpdateAnswerDto input)
        {
            var exam = _questionRepository.FirstOrDefault(input.QuestionId)
                       ?? throw new UserFriendlyException(L("ExamNotFound"));

            if (exam.CreatorUserId != AbpSession.UserId && AbpSession.UserId > 2)
                throw new AbpAuthorizationException();

            var entity = MapToEntity(input);
            entity.UpdateCreator(AbpSession.GetUserId());
            Repository.Insert(entity);
            CurrentUnitOfWork.SaveChanges();
            return MapToEntityDto(entity);
        }

        public override AnswerDto Update(AnswerDto input)
        {
            var item = Repository.Get(input.Id);
            if (item.CreatorUserId != AbpSession.UserId && AbpSession.UserId > 2)
                return input;

            var entityById = GetEntityById(input.Id);
            entityById.Update(input.Name, input.IsCorrect, input.Order, AbpSession.GetUserId());
            CurrentUnitOfWork.SaveChanges();
            return MapToEntityDto(entityById);
        }

        public override void Delete(EntityDto<Guid> input)
        {
            var item = Repository.Get(input.Id);
            if (item.CreatorUserId == AbpSession.UserId || AbpSession.UserId <= 2)
                base.Delete(input);
        }

        protected override IQueryable<Answer> ApplySorting(IQueryable<Answer> query, PagedAnswerResultRequestDto input)
        {
            return query.OrderBy(m => m.Order);
        }

        protected override IQueryable<Answer> CreateFilteredQuery(PagedAnswerResultRequestDto input)
        {
            return Repository.GetAll().Where(m => m.QuestionId.Equals(input.QuestionId));
        }
    }
}
