using System;

namespace Composability.MultipleProcessors
{
    class MultipleProcessorsRunner
    {
        public static void Run(Document doc1, Document doc2)
        {
            Console.WriteLine("Processing document 1");
            DocumentProcessor.Process(doc1);
            Console.WriteLine();
            Console.WriteLine("Processing document 2");
            DocumentProcessor.Process(doc2);
        }
    }
}
