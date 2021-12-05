using Composability.FunctionalComposition;
using Composability.GenericActions;
using System;
using System.Collections.Generic;

namespace Composability
{
    class Program
    {
        static void Main(string[] args)
        {
            var docs = GetDocs();

            //MultipleProcessorsRunner.Run(doc1, doc2);

            //OneAndOnlyProcessorRunner.Run(doc1, doc2);

            //FunctionalCompositionRunner.Run(docs[0], docs[1]);

            GenericActionsRunner.Run(docs[0], docs[1]);

            Console.ReadKey();
        }

        private static List<Document> GetDocs()
        {
            return new List<Document>
            {
                new Document
                {
                    Author = "Matthew Adams",
                    DocumentDate = new DateTime(2000, 01, 01),
                    Text = "Am I a year early?"
                },

                new Document
                {
                    Author = "Ian Griffiths",
                    DocumentDate = new DateTime(2001, 01, 01),
                    Text = "This is the new millennium, I promise you."
                }
            };
        }
    }
}
