using EventStore.ClientAPI;

namespace EventSourcingTaskApp.Infrastructure
{
    public class AggregateRepository
    {
        private readonly IEventStoreConnection _eventStore;

        public AggregateRepository(IEventStoreConnection eventStore)
        {
            _eventStore = eventStore;
        }
    }
}
