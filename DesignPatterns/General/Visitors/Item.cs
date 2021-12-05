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

    public class Book : Item
    {
        public Book(int id, double price) : base(id, price)
        {
        }
    }

    public class Vinyl : Item
    {
        public Vinyl(int id, double price) : base(id, price)
        {
        }
    }
}