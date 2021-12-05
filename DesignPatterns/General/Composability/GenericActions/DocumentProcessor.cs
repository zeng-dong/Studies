using System;
using System.Collections.Generic;

namespace Composability.GenericActions
{
    class DocumentProcessor
    {
        private readonly List<Action<Document>> processes = new List<Action<Document>>();
        public List<Action<Document>> Processes
        {
            get
            {
                return processes;
            }
        }
        public void Process(Document doc)
        {
            foreach (Action<Document> process in Processes)
            {
                process(doc);
            }
        }
    }
}
