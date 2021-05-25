﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainEventsWithMediatr.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity GetById(Guid id);
        List<TEntity> GetAll();
        Task Save(TEntity entity);
    }
}
