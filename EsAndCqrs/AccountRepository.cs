using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace EsAndCqrs
{
    public class AccountRepository
    {

        private class EventDescriptor
        {
            public Guid AggregateId { get; set; }
            public long EventId { get; set; }
            public string EventData { get; set; }
            public string User { get; set; }
            public Guid CorrelationId { get; set; }
        }


        public void Save(Account account)
        {
            var evnts = account.UncommitedEvents.ToList();
            // save
            evnts.Select(e => new EventDescriptor
            {
                AggregateId = account.Id,
                EventId = 0,
                EventData = JsonSerializer.Serialize(account),
                User = Environment.UserName,
                CorrelationId = Guid.NewGuid()
            });

            // persist: ctx.Events.AddRange

            account.Commit();
        }

        public Account Load(Guid id)
        {
            // load all events where aggregate/streamId == id,
            // hard coded here
            var evnts = new List<Event>
            {
                new AccountOpened(),
                new MoneyTransferred(),
                new MoneyTransferred(),
                new MoneyTransferred(),
                new MoneyTransferred(),
                new MoneyTransferred(),
            };

            var account = new Account().Rehydrate(evnts);

            return account;
        }
    }
}
