using System;
using System.Collections.Generic;
using System.Linq;

namespace EventSourcingTaskApp.Core.Framework
{
    public abstract class Aggregate
    {
        readonly IList<object> _changes = new List<object>();

        public Guid Id { get; protected set; } = Guid.Empty;
        public long Version { get; private set; }

        protected abstract void When(object @event);

        public void Apply(object @event)
        {
            When(@event);

            _changes.Add(@event);
        }

        public void Load(long version, IEnumerable<object> history)  //method that will apply the events to aggregate. The final version of aggregate will be 
                                                                     // created by running this method for each event read from ES
        {
            Version = version;

            foreach (var e in history)
            {
                When(e);
            }
        }

        public object[] GetChanges() => _changes.ToArray(); // while sending events to ES, this method will be run and events will be received
    }
}
