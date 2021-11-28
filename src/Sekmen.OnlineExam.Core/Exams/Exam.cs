﻿using Abp.Domain.Entities.Auditing;
using System;

namespace Sekmen.OnlineExam.Exams
{
    public class Exam : AuditedAggregateRoot<Guid>
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Duration { get; protected set; }
        public bool IsActive { get; protected set; }

        protected Exam()
        {
        }

        public Exam(string name, string description, int duration)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Duration = duration;
            IsActive = true;
        }

        public void Update(string name, string description, int duration, bool isActive)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Duration = duration;
            IsActive = isActive;
        }
    }
}