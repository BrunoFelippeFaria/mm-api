using Microsoft.EntityFrameworkCore;

namespace MM.Infrastructure.Persistence.Context;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    
}