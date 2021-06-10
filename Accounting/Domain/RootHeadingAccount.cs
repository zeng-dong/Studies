namespace Accounting.Domain
{
    public class RootHeadingAccount : HeadingAccountBase, IAccount
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Number { get; private set; }
    }
}
