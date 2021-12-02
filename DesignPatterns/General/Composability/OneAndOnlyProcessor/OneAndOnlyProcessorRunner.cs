using System;

namespace Composability.OneAndOnlyProcessor
{
    class OneAndOnlyProcessorRunner
    {
        public static void Run(Document doc1, Document doc2)
        {
            DocumentProcessor processor = Configure();

            Console.WriteLine("Processing document 1");
            processor.Process(doc1);
            Console.WriteLine();
            Console.WriteLine("Processing document 2");
            processor.Process(doc2);
        }

        private static DocumentProcessor Configure()
        {
            DocumentProcessor rc = new DocumentProcessor();
            rc.Processes.Add(new TranslateIntoFrenchProcess());
            rc.Processes.Add(new SpellcheckProcess());
            rc.Processes.Add(new RepaginateProcess());
            return rc;
        }
    }
}
