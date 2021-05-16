using System;

namespace EventSourcingTaskApp.Core.Events
{
    public class TaskCreated
    {
        public Guid TaskId { get; set; }
        public string CreatedBy { get; set; }
        public string Title { get; set; }
    }
}
