
using Mediator;

using MM.Application.Auth.Exceptions;
using MM.Application.Auth.Interfaces;
using MM.Application.Shared.Interfaces;
using MM.Domain.Shared.Exceptions;
using MM.Domain.Shared.Interfaces;

namespace MM.Application.Auth.Commands.Login;

public class LoginCommandHandler (
    IUsersDao userDao,
    IPasswordHasher passwordHasher,
    ITokenGenerator tokenGenerator
)
    : IRequestHandler<LoginCommand, string>
{
    private readonly IUsersDao _userDao = userDao;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

    public async ValueTask<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {            
        var user = await _userDao.GetByAuthEmail(request.Email)
            ?? throw new InvalidCredentialsException();

        if (!_passwordHasher.Verify(request.Password, user.Hash))
            throw new InvalidCredentialsException();

        var token = _tokenGenerator.GenerateJwtToken(user);

        return token;
    }
}