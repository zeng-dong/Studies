using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace Marketplace.Domain.UsingFunctionalExtensions
{
    public class Discount : ValueObject
    {
        public decimal Amount { get; }

        public Discount(decimal amount) => Amount = amount;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}
