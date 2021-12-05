using System;

namespace Visitors
{
    public interface IVisitor
    {
        void VisitBook(Book book);

        void VisitViny(Vinyl vinyl);

        void Print();
    }

    public interface IVisitableElement
    {
        void Accetp(IVisitor visitor);
    }

    public class DiscountVisitor : IVisitor
    {
        private double _savings;

        public void Print()
        {
            Console.WriteLine($"\nYou saved total of ${_savings} on today's order");
        }

        public void VisitBook(Book book)
        {
            double discount = 0.0;
            if (book.Price < 20.00)
            {
                discount = book.GetDiscount(0.10);
                Console.WriteLine($"Discounted: Book #{book.Id} is now ${book.Price - discount }");
            }
            else
            {
                Console.WriteLine($"Full Price: Book #{book.Id} is ${book.Price}");
            }

            _savings += discount;
        }

        public void VisitViny(Vinyl vinyl)
        {
            var discount = vinyl.GetDiscount(0.15);
            Console.WriteLine($"Super Savings: Book #{vinyl.Id} is now ${vinyl.Price - discount }");

            _savings += discount;
        }
    }
}