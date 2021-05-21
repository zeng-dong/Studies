using System;
using System.Collections.Generic;

namespace EventStoreConsoleApp
{
    public class BankAccount
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal CurrentBalance { get; set; }
        public List<Transaction> Transactions => new List<Transaction>();

        public void Apply(AccountCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            CurrentBalance = 0;
        }

        public void Apply(FundsDeposited @event)
        {
            var newTransaction = new Transaction { Id = @event.Id, Amount = @event.Amount };
            Transactions.Add(newTransaction);
            CurrentBalance = CurrentBalance + @event.Amount;
        }

        public void Apply(FundsWithdrawed @event)
        {
            var newTransaction = new Transaction { Id = @event.Id, Amount = @event.Amount };
            Transactions.Add(newTransaction);
            CurrentBalance = CurrentBalance - @event.Amount;
        }
    }

    public class Transaction
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }

        //public Transaction(Guid id, decimal amount)
        //{
        //    Id = id;
        //    Amount = amount;
        //}
    }
}
