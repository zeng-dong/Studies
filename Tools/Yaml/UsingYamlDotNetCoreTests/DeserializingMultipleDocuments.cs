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

namespace UsingYamlDotNetCoreTests
{
    public class DeserializingMultipleDocuments
    {
        private readonly ITestOutputHelper output;

        public DeserializingMultipleDocuments(ITestOutputHelper output)
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

            while (parser.MoveNext())
            {
                var doc = deserializer.Deserialize<List<string>>(parser);

                output.WriteLine("## Document");
                foreach (var item in doc)
                {
                    output.WriteLine(item);
                }
            }
        }

        private const string Document = @"---
- Prisoner
- Goblet
- Phoenix
---
- Memoirs
- Snow 
- Ghost		
...";
    }
}
