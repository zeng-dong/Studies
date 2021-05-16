using System;

namespace EventSourcingTaskApp.Core.Events
{
    public class TaskAssigned
    {
        public Guid TaskId { get; set; }
        public string AssignedBy { get; set; }
        public string AssignedTo { get; set; }
    }
}
