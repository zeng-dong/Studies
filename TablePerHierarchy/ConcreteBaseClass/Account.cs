using System;

namespace TablePerHierarchy.ConcreteBaseClass
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }

        public Account(string name)
        {
            Name = name;
        }
    }

    public class PostingAccount : Account
    {
        public decimal Amount { get; private set; }

        public PostingAccount(string name) : base(name)
        {
        }

        public PostingAccount(string name, decimal amount) : base(name)
        {
            Amount = amount;
        }
    }

    public class HeadingAccount : Account
    {
        public string Description { get; private set; }

        public HeadingAccount(string name, string description) : base(name)
        {
            Description = description;
        }
    }
}
