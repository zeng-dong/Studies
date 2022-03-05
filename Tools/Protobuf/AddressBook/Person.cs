using ProtoBuf;

namespace AddressBook;

[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
class Person
{
    //[ProtoMember(1)]
    public string FirstName { get; set; }

    //[ProtoMember(2)]
    public string LastName { get; set; }

    //[ProtoMember(3)]
    public List<string> Emails { get; set; }

    public decimal Amount { get; set; }
}

class Account
{
    public string Id { get; set; }

    public string Name { get; set; }

    public decimal Amount { get; set; }
}