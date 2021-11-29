using Abp.Domain.Entities.Auditing;
using System;

namespace Sekmen.OnlineExam.Exams
{
    public class Question : AuditedAggregateRoot<Guid>
    {
        public Exam Exam { get; protected set; }
        public Guid ExamId { get; protected set; }
        public string Name { get; protected set; }
        public int Order { get; protected set; }

        protected Question()
        {
        }

        public Question(Exam exam, string name, int order)
        {
            Exam = exam;
            ExamId = exam.Id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Order = order;
        }

        public void Update(string name, int order, long userId)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
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
