using System;
using System.Collections.Generic;

namespace Composability.FunctionalComposition
{
    class TrademarkFilter
    {
        readonly List<string> trademarks = new List<string>();
        public List<string> Trademarks
        {
            get
            {
                return trademarks;
            }
        }
        public void HighlightTrademarks(Document doc)
        {
            string[] words = doc.Text.Split(' ', '.', ',');
            foreach (string word in words)
            {
                if (Trademarks.Contains(word))
                {
                    Console.WriteLine("Highlighting '{0}'", word);
                }
            }
        }
    }
}
