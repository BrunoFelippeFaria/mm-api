using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using MM.Domain.Management.Users.Entities;
using MM.Domain.Shared.Interfaces;
using MM.Infrastructure.Persistence.Context;

namespace MM.Infrastructure.Persistence.Seeds;

public class AdminSeed(AppDbContext context, IPasswordHasher passwordHasher) : ISeed
{
    private readonly AppDbContext _context = context;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task Seed()
    {
        if (await _context.Users.IgnoreQueryFilters().AnyAsync())
            return;

        _context.Users.Add(new User
        {
            Id = 1,
            Name = "admin",
            Email = "admin",
            Hash = _passwordHasher.Hash("admin")
        });

        await _context.SaveChangesAsync();
    }
}