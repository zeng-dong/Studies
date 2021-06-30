using DddEnittyframeworkcoreThree.PreservingEncapsulation.Core;
using System.Collections.Generic;

namespace DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Domain
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }
    }
}
