using System;

namespace EsAndCqrs
{
    internal class MoneyTransferred : Event
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public string Iban { get; private set; }

        public MoneyTransferred(Guid id, decimal amount, string iban)
        {
            Id = id;
            Amount = amount;
            Iban = iban;
        }
    }
}
