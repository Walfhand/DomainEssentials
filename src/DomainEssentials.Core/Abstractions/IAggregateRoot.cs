using DomainEssentials.Core.Events;

namespace DomainEssentials.Core.Abstractions;

public interface IAggregateRoot : IAudit
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    IDomainEvent[] ClearDomainEvents();
}