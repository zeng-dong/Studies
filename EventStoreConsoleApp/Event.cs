using System;

namespace EventStoreConsoleApp
{
    public interface IEvent
    {
        Guid Id { get; }
    }

    public class AccountCreated : IEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public AccountCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class FundsDeposited : IEvent
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }

        public FundsDeposited(Guid id, decimal amount)
        {
            Id = id;
            Amount = amount;
        }
    }

    public class FundsWithdrawed : IEvent
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public string Reason { get; private set; }
        public FundsWithdrawed(Guid id, decimal amount, string reason)
        {
            Id = id;
            Amount = amount;
            Reason = reason;
        }
    }
}
