using MM.Application.Auth.Dtos;

namespace MM.Application.Shared.Interfaces;

public interface IUsersDao
{
    public Task<UserAuthDto?> GetByAuthEmail(string email);
}