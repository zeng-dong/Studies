using System;

namespace EventSourcingTaskApp.Core.Events
{
    public class TaskMoved
    {
        public Guid TaskId { get; set; }
        public string MovedBy { get; set; }
        public BoardSections Section { get; set; }
    }
}
