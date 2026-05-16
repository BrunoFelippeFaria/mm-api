using MM.Domain.Management.Users.Entities;

namespace MM.Application.Auth.Interfaces;

public interface ITokenGenerator
{
    public string GenerateJwtToken(User user);
}