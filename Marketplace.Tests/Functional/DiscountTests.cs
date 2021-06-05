using Marketplace.Domain.UsingFunctionalExtensions;
using Xunit;

namespace Marketplace.Tests.Functional
{
    public class DiscountTests
    {
        [Fact]
        public void Discount_object_with_the_same_amount_should_be_equal()
        {
            var firstAmount = new Discount(5);
            var secondAmount = new Discount(5);
            Assert.Equal(firstAmount, secondAmount);
        }
    }
}
