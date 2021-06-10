namespace Accounting.Domain
{
    public interface IAccount
    {
        string Name { get; }
        string Description { get; }
        string Number { get; }
    }
}
