using MM.Domain.Shared.Exceptions;

namespace MM.Application.Auth.Exceptions;

public class InvalidCredentialsException() 
    : UnauthorizedException("Email ou Senha Incorretos.")
{
    public override string Code => "invalid_credentials";
}