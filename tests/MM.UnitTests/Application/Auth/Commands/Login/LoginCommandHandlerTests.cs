using System.Threading.Tasks;

using FluentAssertions;

using MM.Application.Auth.Commands.Login;
using MM.Application.Auth.Dtos;
using MM.Application.Auth.Exceptions;
using MM.Application.Auth.Interfaces;
using MM.Application.Shared.Interfaces;
using MM.Domain.Shared.Interfaces;

using NSubstitute;

namespace MM.UnitTests.Application.Auth.Commands.Login;

public class LoginCommandHandlerTests
{
    private readonly IUsersDao _userDao;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly LoginCommandHandler _handler;

    public LoginCommandHandlerTests()
    {
        _userDao = Substitute.For<IUsersDao>();
        _passwordHasher = Substitute.For<IPasswordHasher>();
        _tokenGenerator = Substitute.For<ITokenGenerator>();

        _handler = new(_userDao, _passwordHasher, _tokenGenerator);
    }

    [Fact]
    public async Task Handle_UserNotFound_TrowsInvalidCredentialsException()
    {
        _userDao.GetByAuthEmail(Arg.Any<string>()).Returns((UserAuthDto?)null);

        var act = async () => await _handler.Handle(new LoginCommand { Email = "test@email.com", Password = "123" }, default);

        await act.Should().ThrowAsync<InvalidCredentialsException>();
    }

    [Fact]
    public async Task Handle_WrongCredentials_TrowsInvalidCredentialsException()
    {
        var dto = new UserAuthDto { Id = 1, Name = "name", Email = "email", Hash = "hash" };
        
        _userDao.GetByAuthEmail(Arg.Any<string>()).Returns(dto);
        _passwordHasher.Verify(Arg.Any<string>(), "hash").Returns(false);

        var act = async () => await _handler.Handle(new LoginCommand { Email = "test@email.com", Password = "123" }, default);

        await act.Should().ThrowAsync<InvalidCredentialsException>();
    }

    [Fact]
    public async Task Handle_LoginSucefull_ReturnsToken()
    {
        var dto = new UserAuthDto
        {
            Id = 1,
            Name = "name",
            Email = "email",
            Hash = "hash",
        };

        _userDao.GetByAuthEmail(Arg.Any<string>()).Returns(dto);
        _passwordHasher.Verify(Arg.Any<string>(), "hash").Returns(true);
        _tokenGenerator.GenerateJwtToken(dto).Returns("token");

        var result = await _handler.Handle(new LoginCommand { Email = "test@email.com", Password = "123" }, default);

        result.Should().Be("token");
    }
}