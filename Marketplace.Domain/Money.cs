using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class Money : Value<Money>
    {
        public decimal Amount { get; }
        public Money(decimal amount) => Amount = amount;

        public Money Add(Money summand) => new Money(Amount + summand.Amount);
        public Money Subtract(Money subtrahend) => new Money(Amount - subtrahend.Amount);
        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);
        public static Money operator -(Money minuend, Money subtrahend) => minuend.Subtract(subtrahend);

        //public bool Equals([AllowNull] Money other)
        //{
        //    if (ReferenceEquals(null, other)) return false;
        //    if (ReferenceEquals(this, other)) return true;
        //    return Amount.Equals(other.Amount);
        //}
        //
        //public override bool Equals(object obj)
        //{
        //    if (ReferenceEquals(null, obj)) return false;
        //    if (ReferenceEquals(this, obj)) return true;
        //    if (obj.GetType() != this.GetType()) return false;
        //    return Equals((Money)obj);
        //}
        //
        //public override int GetHashCode() => Amount.GetHashCode();
        //
        //public static bool operator ==(Money left, Money right) => Equals(left, right);
        //public static bool operator !=(Money left, Money right) => !Equals(left, right);
    }
}
