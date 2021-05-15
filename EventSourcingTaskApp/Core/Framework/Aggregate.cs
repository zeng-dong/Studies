using System;
using System.Collections.Generic;

namespace EventSourcingTaskApp.Core.Framework
{
    public abstract class Aggregate
    {
        readonly IList<object> _changes = new List<object>();

        public Guid Id { get; protected set; } = Guid.Empty;
        public long Version { get; private set; }
    }
}
