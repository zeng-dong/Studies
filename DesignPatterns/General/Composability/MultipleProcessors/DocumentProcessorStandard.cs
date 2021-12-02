namespace Composability.MultipleProcessors
{
    static class DocumentProcessorStandard
    {
        public static void Process(Document doc)
        {
            DocumentProcesses.Spellcheck(doc);
            DocumentProcesses.Repaginate(doc);
        }
    }
}


/*
 each DocumentProcessor is coupled to the Document class
 each DocumentProcessor is coupled also to each method that it calls on the DocumentProcesses class

 client app is coupled to the Document and each DocumentProcessor class that it uses.
 
 */
