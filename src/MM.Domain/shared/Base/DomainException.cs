namespace MM.Domain.Shared.Base;

public abstract class DomainException(string message) : Exception(message)
{
    public abstract string Code { get; }
}