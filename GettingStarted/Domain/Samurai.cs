using System.Collections.Generic;

namespace GettingStarted.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Quote> Quotes { get; set; } = new List<Quote>();

        public List<Battle> Battles { get; set; } = new List<Battle>();

        public Horse Horse { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
