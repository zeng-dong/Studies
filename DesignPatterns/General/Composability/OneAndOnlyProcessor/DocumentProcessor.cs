using System.Collections.Generic;

namespace Composability.OneAndOnlyProcessor
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
                process.Process(doc);
            }
        }
    }
}

/*
 nicer 
 DocumentProcessor is coupled only to the Document class
 DocumentProcessor uses the abstract base as a contract for the individual processes.

 It is no longer coupled to each and every one of those processes; they can vary without requiring any changes to the processor itself, because they implement the contract 
 demanded by the abstract base class.
 */
