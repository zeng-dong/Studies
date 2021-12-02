using System;

namespace Composability.FunctionalComposition
{
    class FunctionalCompositionRunner
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
            rc.Processes.Add(DocumentProcesses.TranslateIntoFrench);
            rc.Processes.Add(DocumentProcesses.Spellcheck);
            rc.Processes.Add(DocumentProcesses.Repaginate);

            // Adding a processing step with a non static method
            TrademarkFilter trademarkFilter = new TrademarkFilter();
            trademarkFilter.Trademarks.Add("O'Reilly");
            trademarkFilter.Trademarks.Add("millennium");

            rc.Processes.Add(trademarkFilter.HighlightTrademarks);

            return rc;
        }
    }
}
