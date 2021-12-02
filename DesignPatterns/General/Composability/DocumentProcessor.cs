﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composability
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
