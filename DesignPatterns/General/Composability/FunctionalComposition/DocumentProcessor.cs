using System.Collections.Generic;

namespace Composability.FunctionalComposition
{
    class DocumentProcessor
    {
        private readonly List<DocumentProcess> processes = new List<DocumentProcess>();

        public List<DocumentProcess> Processes
        {
            get
            {
                return processes;
            }
        }

        public void Process(Document doc)
        {
            foreach (DocumentProcess process in Processes)
            {
                //process.Invoke(doc);
                process(doc);
            }
        }
    }
}

/*
 DocumentProcessor doesn’t depend on any classes other than the Document itself
 
 */
