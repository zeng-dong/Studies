using System;

namespace EventSourcingTaskApp.Core.Events
{
    public class TaskCompleted
    {
        public Guid TaskId { get; set; }
        public string CompletedBy { get; set; }
    }
}
