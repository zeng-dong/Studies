using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Domain;
using System;

namespace DddEnittyframeworkcoreThree.PreservingEncapsulation.Core
{
    public interface IDomainEvent
    {
    }

    public sealed class StudentEmailChangedEvent : IDomainEvent
    {
        public long StudentId { get; }
        public Email NewEmail { get; }

        public StudentEmailChangedEvent(long studentId, Email newEmail)
        {
            StudentId = studentId;
            NewEmail = newEmail;
        }
    }

    public interface IBus
    {
        void Send(string message);
    }

    public class Bus : IBus
    {
        public void Send(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Message sent: '{message}'");
            Console.ResetColor();
        }
    }
}
