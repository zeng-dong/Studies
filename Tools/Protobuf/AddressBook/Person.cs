using ProtoBuf;

namespace AddressBook;

[ProtoContract]
class Person
{
    [ProtoMember(1)]
    public string FirstName { get; set; }

    [ProtoMember(2)]
    public string LastName { get; set; }

    [ProtoMember(3)]
    public List<string> Emails { get; set; }
}