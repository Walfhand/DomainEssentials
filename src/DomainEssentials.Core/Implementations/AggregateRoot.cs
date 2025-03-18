using DomainEssentials.Core.Abstractions;
using DomainEssentials.Core.Events;
using DomainEssentials.Core.Keys;

namespace DomainEssentials.Core.Implementations;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    where TId : IdBase, new()
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();


    public virtual IDomainEvent[] ClearDomainEvents()
    {
        var dequeuedEvents = _domainEvents.ToArray();
        _domainEvents.Clear();
        return dequeuedEvents;
    }

    protected virtual void AddDomainEvent(IDomainEvent domainEvent)
        => _domainEvents.Add(domainEvent);
}