using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace UsingYamlDotNetTests
{
    public class DeserializingMultipleDocumentsToMultipleObjects
    {
        private readonly ITestOutputHelper output;

        public DeserializingMultipleDocumentsToMultipleObjects(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Sample(
            DisplayName = "Deserializing multiple documents",
            Description = "Explains how to load multiple YAML documents from a stream."
        )]
        public void Main()
        {
            var input = new StringReader(Document);

            var deserializer = new DeserializerBuilder().Build();

            var parser = new Parser(input);

            // Consume the stream start event "manually"
            parser.Consume<StreamStart>();

            var count = 0;

            var customers = new List<Customer>();
            var credits = new List<Credit>();

            while (parser.Accept<DocumentStart>(out var _))
            {

                if (count == 0)
                {
                    customers = deserializer.Deserialize<List<Customer>>(parser);

                    output.WriteLine("## Customer");
                    output.WriteLine("-----");
                    output.WriteLine();
                    foreach (var customer in customers)
                    {
                        output.WriteLine("{0}\t{1}", customer.Name, customer.Number);
                    }
                    output.WriteLine();
                }
                else if (count == 1)
                {
                    credits = deserializer.Deserialize<List<Credit>>(parser);

                    output.WriteLine("## Credits");
                    output.WriteLine("-----");
                    output.WriteLine();
                    foreach (var credit in credits)
                    {
                        output.WriteLine("{0}\t{1}\t{2}", credit.Id, credit.Code, credit.Max);
                    }
                    output.WriteLine();

                    foreach (var customer in customers)
                    {
                        output.WriteLine("Can still access customer: {0}\t{1}", customer.Name, customer.Number);
                    }
                }

                count++;
            }
        }

        private const string Document = @"---
- Name: Kroger
  Number: KRG
- Name: Chillis
  Number: CLL
---
- Id: A1
  Code: Master
  Max: 199
- Id: A2
  Code: Visa
  Max: 350            
...";
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }

    public class Credit
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public int Max { get; set; }
    }


}
