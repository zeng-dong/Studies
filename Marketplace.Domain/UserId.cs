using System;

namespace Marketplace.Domain
{
    public class UserId
    {
        readonly Guid _value;

        public UserId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "User id cannot be empty");

            _value = value;
        }
    }
}
