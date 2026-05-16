using MM.Application.Auth.Dtos;
using MM.Domain.Management.Users.Entities;

namespace MM.Application.Auth.Interfaces;

public interface ITokenGenerator
{
    public string GenerateJwtToken(UserAuthDto user);
}