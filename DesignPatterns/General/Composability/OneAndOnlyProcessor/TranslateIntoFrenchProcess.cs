namespace Composability.OneAndOnlyProcessor
{
    class TranslateIntoFrenchProcess : DocumentProcess
    {
        public override void Process(Document doc)
        {
            DocumentProcesses.TranslateIntoFrench(doc);
        }
    }
}
