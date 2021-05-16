using EventSourcingTaskApp.Core.Framework;
using System;

namespace EventSourcingTaskApp.Core
{
    public class Task : Aggregate
    {
        public string Title { get; private set; }
        public BoardSections Section { get; private set; }
        public string AssignedTo { get; private set; }
        public bool IsCompleted { get; private set; }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
