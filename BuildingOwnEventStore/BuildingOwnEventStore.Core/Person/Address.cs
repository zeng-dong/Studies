﻿using System.Collections.Generic;
using Tactical.DDD;

namespace BuildingOwnEventStore.Core.Person
{
    public class Address : ValueObject
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return Country;
            yield return ZipCode;
        }
    }
}
