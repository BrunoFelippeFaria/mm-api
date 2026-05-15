using Microsoft.EntityFrameworkCore;

using MM.Domain.Entities;

namespace MM.Infrastructure.Persistence.Context;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; } 
}