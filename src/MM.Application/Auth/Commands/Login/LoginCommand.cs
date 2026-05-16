using Mediator;

namespace MM.Application.Auth.Commands.Login;

public record LoginCommand : IRequest<string>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}