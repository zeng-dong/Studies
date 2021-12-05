using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors
{
    internal class BookStoreProgram
    {
        internal static void Run()
        {
            List<IVisitableElement> items = new List<IVisitableElement>
            {
                new Book(12345, 11.99),
                new Book(78910, 22.79),
                new Vinyl(11198, 17.99),
                new Book(66634, 9.99)
            };

            var discountVisitor = new DiscountVisitor();
            foreach (var item in items)
            {
                item.Accetp(discountVisitor);
            }

            discountVisitor.Print();

            var salesVisitor = new SalesVisitor();
            foreach (var item in items) item.Accetp(salesVisitor);

            salesVisitor.Print();
        }
    }
}