using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Sekmen.OnlineExam.Exams;
using Sekmen.OnlineExam.ExamsQuestions.Dto;
using System;
using System.Linq;

namespace Sekmen.OnlineExam.ExamsQuestions
{
    public class QuestionAppService : CrudAppService<Question, QuestionDto, Guid, PagedQuestionResultRequestDto, CreateUpdateQuestionDto, QuestionDto>, IQuestionAppService
    {
        private readonly IRepository<Exam, Guid> _examRepository;

        public QuestionAppService(IRepository<Question, Guid> repository, IRepository<Exam, Guid> examRepository) : base(repository)
        {
            _examRepository = examRepository;
        }

        public override QuestionDto Create(CreateUpdateQuestionDto input)
        {
            var exam = _examRepository.FirstOrDefault(input.ExamId)
                ?? throw new UserFriendlyException(L("ExamNotFound"));

            if (exam.CreatorUserId != AbpSession.UserId && AbpSession.UserId > 2)
                throw new AbpAuthorizationException();

            return base.Create(input);
        }

        public override QuestionDto Update(QuestionDto input)
        {
            var item = Repository.Get(input.Id);
            if (item.CreatorUserId != AbpSession.UserId && AbpSession.UserId > 2)
                return input;

            var entityById = GetEntityById(input.Id);
            entityById.Update(input.Name, input.Order, AbpSession.GetUserId());
            CurrentUnitOfWork.SaveChanges();
            return MapToEntityDto(entityById);
        }

        public override void Delete(EntityDto<Guid> input)
        {
            var item = Repository.Get(input.Id);
            if (item.CreatorUserId == AbpSession.UserId || AbpSession.UserId <= 2)
                base.Delete(input);
        }

        protected override IQueryable<Question> CreateFilteredQuery(PagedQuestionResultRequestDto input)
        {
            return Repository.GetAll().Where(m => m.ExamId.Equals(input.ExamId));
        }
    }
}
