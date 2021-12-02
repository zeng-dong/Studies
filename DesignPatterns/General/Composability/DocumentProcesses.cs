using System;

namespace Composability
{
    static class DocumentProcesses
    {
        public static void Spellcheck(Document doc)
        {
            Console.WriteLine("Spellchecked document.");
        }
        public static void Repaginate(Document doc)
        {
            Console.WriteLine("Repaginated document.");
        }
        public static void TranslateIntoFrench(Document doc)
        {
            Console.WriteLine("Document traduit.");
        }
        // ...
    }
}
