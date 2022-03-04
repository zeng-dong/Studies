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
            Console.WriteLine($"{ myPerson.FirstName}, with amount = {person.Amount}");
        }
    }
}