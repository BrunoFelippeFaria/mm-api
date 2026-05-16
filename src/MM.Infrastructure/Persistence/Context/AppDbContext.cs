using Microsoft.EntityFrameworkCore;

using MM.Domain.Management.Users.Entities;
using MM.Domain.Sales.Customers.Entities;

namespace MM.Infrastructure.Persistence.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<Customer> Customers { get; set; } 
    public DbSet<User> Users { get; set; } 
}