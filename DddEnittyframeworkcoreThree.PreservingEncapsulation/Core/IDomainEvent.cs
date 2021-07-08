﻿using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Domain;

namespace DddEnittyframeworkcoreThree.PreservingEncapsulation.Core
{
    public interface IDomainEvent
    {
    }

    public class StudentEmailChangedEvent : IDomainEvent
    {
        public long StudentId { get; }
        public Email NewEmail { get; }

        public StudentEmailChangedEvent(long studentId, Email newEmail)
        {
            StudentId = studentId;
            NewEmail = newEmail;
        }
    }
}
