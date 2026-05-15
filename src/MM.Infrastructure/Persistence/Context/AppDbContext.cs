using Microsoft.EntityFrameworkCore;

using MM.Domain.Sales.Customers.Entities;

namespace MM.Infrastructure.Persistence.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; } 
}