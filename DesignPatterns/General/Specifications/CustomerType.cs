namespace Specifications
{
    public class CustomerType : Enumeration
    {
        public static readonly CustomerType Best = new(1, "Best");

        public static readonly CustomerType Better = new(2, "Better");

        public static readonly CustomerType Good = new(3, "Good");

        public CustomerType()
        {
        }

        public CustomerType(int value, string displayName) : base(value, displayName)
        {
        }
    }
}