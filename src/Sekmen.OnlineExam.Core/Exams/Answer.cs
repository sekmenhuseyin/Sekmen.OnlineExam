using Abp.Domain.Entities.Auditing;
using System;

namespace Sekmen.OnlineExam.Exams
{
    public class Answer : AuditedAggregateRoot<Guid>
    {
        public Question Question { get; protected set; }
        public Guid QuestionId { get; protected set; }
        public string Name { get; protected set; }
        public bool IsCorrect { get; protected set; }
        public int Order { get; protected set; }

        protected Answer()
        {
        }

        public Answer(Question question, string name, bool isCorrect, int order)
        {
            Question = question ?? throw new ArgumentNullException(nameof(question));
            QuestionId = question.Id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            IsCorrect = isCorrect;
            Order = order;
        }

        public void Update(string name, bool isCorrect, int order, long userId)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            IsCorrect = isCorrect;
            Order = order;
            UpdateModifier(userId);
        }

        public void UpdateCreator(long userId)
        {
            CreatorUserId = userId;
        }

        public void UpdateModifier(long userId)
        {
            LastModificationTime = DateTime.Now;
            LastModifierUserId = userId;
        }
    }
}
