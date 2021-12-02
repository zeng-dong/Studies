namespace Composability.OneAndOnlyProcessor
{
    class RepaginateProcess : DocumentProcess
    {
        public override void Process(Document doc)
        {
            DocumentProcesses.Repaginate(doc);
        }
    }
}
