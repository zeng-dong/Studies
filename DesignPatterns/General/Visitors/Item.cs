using System;

namespace Visitors
{
    public class Item
    {
        public int Id;
        public double Price;

        public Item(int id, double price)
        {
            Id = id;
            Price = price;
        }

        public double GetDiscount(double percentage)
        {
            return Math.Round(Price * percentage, 2);
        }
    }

    public class Book : Item, IVisitableElement
    {
        public Book(int id, double price) : base(id, price)
        {
        }

        public void Accetp(IVisitor visitor)
        {
            visitor.VisitBook(this);
        }
    }

    public class Vinyl : Item, IVisitableElement
    {
        public Vinyl(int id, double price) : base(id, price)
        {
        }

        public void Accetp(IVisitor visitor)
        {
            visitor.VisitViny(this);
        }
    }
}