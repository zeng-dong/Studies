using System;
using System.Collections.Generic;
using System.Linq;

namespace Rules
{
    internal class RuleEvaluator
    {
        private IEnumerable<IRule> _rules;

        public void Execute(Context context)
        {
            var result = _rules
                .Where(rule => rule.IsApplicable(context))
                .Select(rule => rule.Execute(context));

            if (result != null && result.Any())
            {
                result.ToList().ForEach(rule => Console.WriteLine(rule));
            }
        }

        public RuleEvaluator(IEnumerable<IRule> rules)
        {
            _rules = rules;
        }
    }
}