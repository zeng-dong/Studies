namespace Composability.OneAndOnlyProcessor
{
    class SpellcheckProcess : DocumentProcess
    {
        public override void Process(Document doc)
        {
            DocumentProcesses.Spellcheck(doc);
        }
    }
}
