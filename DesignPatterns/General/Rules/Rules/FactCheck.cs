using System;
using System.Collections.Generic;
using System.Linq;

namespace Rules.Rules
{
    internal class FactCheck : IRule
    {
        private readonly List<DateTime> _events;

        public FactCheck()
        {
            _events = new List<DateTime>();
            _events.Add(new DateTime(1914, 7, 28));
            _events.Add(new DateTime(1918, 11, 11));
        }

        public string Execute(Context ctx)
        {
            if (_events.Contains(ctx.Date)) return "Start of world war 1 or End of world war 1";

            if (ctx.Date >= _events.First() && ctx.Date <= _events.Last()) return "during world 1";

            return "Information not in fact database";
        }

        public bool IsApplicable(Context ctx)
        {
            if (ctx.InPast) return true;

            return false;
        }
    }
}