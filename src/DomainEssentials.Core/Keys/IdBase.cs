namespace DomainEssentials.Core.Keys;

public record IdBase(Guid Value)
{
    protected IdBase() : this(Guid.NewGuid())
    {
    }

    public static implicit operator Guid(IdBase id) => id.Value;
    public static implicit operator IdBase(Guid value) => new(value);
}