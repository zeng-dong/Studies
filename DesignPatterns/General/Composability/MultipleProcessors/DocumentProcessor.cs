namespace Composability.MultipleProcessors
{
    static class DocumentProcessor
    {
        public static void Process(Document doc)
        {
            DocumentProcesses.TranslateIntoFrench(doc);
            DocumentProcesses.Spellcheck(doc);
            DocumentProcesses.Repaginate(doc);
        }
    }
}
