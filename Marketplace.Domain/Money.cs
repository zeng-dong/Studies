﻿namespace Marketplace.Domain
{
    public class Money
    {
        public decimal Amount { get; }
        public Money(decimal amount) => Amount = amount;
    }
}
