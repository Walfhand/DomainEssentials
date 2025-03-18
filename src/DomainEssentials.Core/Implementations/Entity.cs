using DomainEssentials.Core.Keys;

namespace DomainEssentials.Core.Implementations;

public abstract class Entity<TId> : Audit
    where TId : IdBase, new()
{
    public TId Id { get; protected set; } = new();
}