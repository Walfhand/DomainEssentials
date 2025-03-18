namespace DomainEssentials.Core.Exceptions;

public abstract class DomainException(string message) : Exception(message)
{
}