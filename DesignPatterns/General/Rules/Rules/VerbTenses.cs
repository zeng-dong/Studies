using System;

namespace Rules.Rules
{
    internal class VerbTenses : IRule
    {
        public string Execute(Context context)
        {
            if (context.Date < DateTime.Today) return "In Past";

            context.InPast = false;

            if (context.Date == DateTime.Today) return "Present";

            return "In Future";
        }

        public bool IsApplicable(Context context)
        {
            if (context.Date == DateTime.MinValue) return false;
            return true;
        }
    }
}