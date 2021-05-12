using System;
using System.Collections.Generic;

namespace EsAndCqrs
{
    public class Account
    {
        private Guid Id { get; set; }
        private decimal CurrentAmount { get; set; }

        public ICollection<Event> UncommitedEvents { get; } = new List<Event>();

        public void Open(string owner, string iban)
        {
            UncommitedEvents.Add(new AccountOpened(Id, owner, iban));
        }

        public void TransferMoney(decimal amount, string iban)
        {
            if (CurrentAmount < amount)
                throw new InvalidOperationException("Not enough money");

            UncommitedEvents.Add(new MoneyTransferred(Id, amount, iban));
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
