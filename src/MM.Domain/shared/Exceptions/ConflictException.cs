using MM.Domain.Shared.Base;

namespace MM.Domain.Shared.Exceptions;

public class ConflictException(string message) : DomainException(message)
{
    public override string Code => "conflict";
}