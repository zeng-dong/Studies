using System;

namespace Rules
{
    internal class Context
    {
        public bool InPast { get; set; } = true;
        public DateTime Date { get; set; }
    }
}