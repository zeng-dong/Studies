using Composability.OneAndOnlyProcessor;
using System;

namespace Composability
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc1 = new Document
            {
                Author = "Matthew Adams",
                DocumentDate = new DateTime(2000, 01, 01),
                Text = "Am I a year early?"
            };
            Document doc2 = new Document
            {
                Author = "Ian Griffiths",
                DocumentDate = new DateTime(2001, 01, 01),
                Text = "This is the new millennium, I promise you."
            };

            //MultipleProcessorsRunner.Run(doc1, doc2);

            OneAndOnlyProcessorRunner.Run(doc1, doc2);

            Console.ReadKey();
        }
    }
}
