
using Mediator;

namespace MM.Application.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Unit>
{
    public ValueTask<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}