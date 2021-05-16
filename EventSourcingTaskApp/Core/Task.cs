using EventSourcingTaskApp.Core.Events;
using EventSourcingTaskApp.Core.Exceptions;
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

        public void Create(Guid taskId, string title, string createdBy)
        {
            if (Version >= 0) throw new TaskAlreadyCreatedException();

            Apply(new TaskCreated
            {
                TaskId = taskId,
                CreatedBy = createdBy,
                Title = title,
            });
        }

        private void OnCreated(TaskCreated @event)
        {
            Id = @event.TaskId;
            Title = @event.Title;
            Section = BoardSections.Open;
        }
    }
}
