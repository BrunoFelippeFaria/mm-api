using Microsoft.EntityFrameworkCore;

using MM.Application.Auth.Dtos;
using MM.Application.Shared.Interfaces;
using MM.Infrastructure.Persistence.Context;

namespace MM.Infrastructure.Persistence.Daos;

public class UsersDao(AppDbContext context) : IUsersDao
{
    private readonly AppDbContext _context = context;

    public async Task<UserAuthDto?> GetByAuthEmail (string email)
    {
        return await _context.Users
            .Where(u => u.Email == email)
            .Select(u => new UserAuthDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Hash = u.Hash
            })
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
}