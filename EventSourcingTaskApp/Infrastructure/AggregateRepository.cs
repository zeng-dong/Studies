using EventSourcingTaskApp.Core.Framework;
using EventStore.ClientAPI;

using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventSourcingTaskApp.Infrastructure
{
    public class AggregateRepository
    {
        private readonly IEventStoreConnection _eventStore;

        public AggregateRepository(IEventStoreConnection eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task SaveAsync<T>(T aggregate) where T : Aggregate, new()
        {
            var events = aggregate.GetChanges()
                .Select(@event => new EventData(
                    Guid.NewGuid(),
                    @event.GetType().Name,
                    true,
                    Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event)),
                    Encoding.UTF8.GetBytes(@event.GetType().FullName)
                    )).ToArray();

            if (!events.Any())
            {
                return;
            }

            var streamName = GetStreamName(aggregate, aggregate.Id);

            var result = await _eventStore.AppendToStreamAsync(streamName, ExpectedVersion.Any, events);
        }

        private string GetStreamName<T>(T type, Guid aggregateId) => $"{type.GetType().Name}-{aggregateId}";
    }
}
