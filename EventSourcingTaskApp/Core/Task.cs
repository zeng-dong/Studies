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
            switch (@event)
            {
                case TaskCreated x: OnCreated(x); break;
                case TaskAssigned x: OnAssigned(x); break;
                case TaskMoved x: OnMoved(x); break;
            }
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

        public void Assign(string assignedTo, string assignedBy)
        {
            if (Version == -1)
            {
                throw new TaskNotFoundException();
            }

            if (IsCompleted)
            {
                throw new TaskCompletedException();
            }

            Apply(new TaskAssigned
            {
                TaskId = Id,
                AssignedBy = assignedBy,
                AssignedTo = assignedTo
            });

        }

        public void Move(BoardSections section, string movedBy)
        {
            if (Version == -1) throw new TaskNotFoundException();

            if (IsCompleted) throw new TaskCompletedException();

            Apply(new TaskMoved
            {
                TaskId = Id,
                MovedBy = movedBy,
                Section = section
            });
        }

        private void OnCreated(TaskCreated @event)
        {
            Id = @event.TaskId;
            Title = @event.Title;
            Section = BoardSections.Open;
        }

        private void OnAssigned(TaskAssigned @event)
        {
            AssignedTo = @event.AssignedTo;
        }

        private void OnMoved(TaskMoved @event)
        {
            Section = @event.Section;
        }

    }
}
