using System;
using System.Linq;
using System.Reactive.Linq;

namespace Rx101
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from number in Enumerable.Range(1, 10) select number;
            var oq = query.ToObservable();

            oq.Subscribe(Console.WriteLine, () => { Console.WriteLine("I am done."); });
        }
    }
}