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


    public class Account
    {
        public Guid Id { get; private set; }
        private decimal CurrentAmount { get; set; }
        private decimal CurrentBalance { get; set; }

        public ICollection<Event> UncommitedEvents { get; } = new List<Event>();
        public void Commit() => UncommitedEvents.Clear();

        private enum State
        {
            NotSet,
            Opened,
            Closed
        }

        private State CurrentState { get; set; } = State.NotSet;

        public void Rehydrate(ICollection<Event> events)
        {
            foreach (var evnt in events)
            {
                ((dynamic)this).Apply((dynamic)evnt);
            }
        }

        private void Apply(AccountOpened evnt) => CurrentState = State.Opened;
        private void Apply(MoneyTransferred evnt) => CurrentBalance -= evnt.Amount;


        public void Open(string owner, string iban)
        {
            // update state to open
            //UncommitedEvents.Add(new AccountOpened(Id, owner, iban));
            var evnt = new AccountOpened(Id, owner, iban);
            UncommitedEvents.Add(evnt);
            Apply(evnt);
        }

        public void TransferMoney(decimal amount, string iban)
        {
            if (CurrentAmount < amount)
                throw new InvalidOperationException("Not enough money");

            var evnt = new MoneyTransferred(Id, amount, iban);
            UncommitedEvents.Add(evnt);
            Apply(evnt);
        }

        public void Close()
        {
            if (State.Opened != CurrentState)
                throw new Exception();
        }

    }

    internal class AccountOpened : Event
    {
        private Guid id;
        private string owner;
        private string iban;

        public AccountOpened(Guid id, string owner, string iban)
        {
            this.id = id;
            this.owner = owner;
            this.iban = iban;
        }
    }

    public class Event
    {
    }
}
