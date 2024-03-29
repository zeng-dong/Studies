﻿using System;
using Tactical.DDD;

namespace BuildingOwnEventStore.Core.Person
{
    public class PersonId : EntityId
    {
        private Guid _guid;

        public PersonId()
        {
            _guid = Guid.NewGuid();
        }

        public PersonId(string id)
        {
            _guid = Guid.Parse(id);
        }

        public override string ToString() => _guid.ToString();
    }
}
