using Rules.Rules;
using System;

namespace Rules
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestIndex.testIndex();
        }

        private static void ruleExample()
        {
            var ctx = new Context() { Date = new DateTime(2014, 7, 28) };

            var rules = new IRule[] {
                new VerbTenses(),
                new FactCheck()
            };
            new RuleEvaulator(rules).Execute(ctx);
        }
    }
}