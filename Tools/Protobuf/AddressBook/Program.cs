using ProtoBuf;

namespace AddressBook;

public class Program
{
    public static void Main(string[] args)
    {
        var person = new Person()
        {
            FirstName = "Wade",
            LastName = "Smith",
            Emails = new List<string>
            {
                "wade.smith@gmail.com",
                "wsmith@company.com"
            },
            Amount = 101
        };

        UseProtoBufSerializerDirectly(person);

        Console.WriteLine("Now clone ....");
        var anotherPerson = SerializationTool.Clone(person);
        Console.WriteLine($"{ anotherPerson.FirstName}, with amount = {anotherPerson.Amount}");

        Console.WriteLine("Now clone without attribute ....");
        var anotherAccount = SerializationTool.Clone(new Account { Amount = 200, Id = "A1", Name = "Checking" });
        Console.WriteLine($"{ anotherAccount.Name}, with amount = {anotherAccount.Amount}");
    }

    private static void UseProtoBufSerializerDirectly(Person person)
    {
        //using (var memoryStream = new MemoryStream())
        //{
        //    Serializer.Serialize(memoryStream, person);
        //    var byteArray = memoryStream.ToArray();
        //}

        using (var fileStream = File.Create("person.buf"))
        {
            Serializer.Serialize(fileStream, person);
        }

        using (var fileStream = File.OpenRead("person.buf"))
        {
            var myPerson = Serializer.Deserialize<Person>(fileStream);
            Console.WriteLine($"{ myPerson.FirstName}, with amount = {myPerson.Amount}");
        }
    }
}