using MediatR;
using System;
using System.Collections.Generic;

namespace DomainEventsWithMediatr.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; }
        List<INotification> Events { get; }
    }
}
