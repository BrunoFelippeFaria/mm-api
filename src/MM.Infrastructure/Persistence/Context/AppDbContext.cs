using Microsoft.EntityFrameworkCore;

using MM.Domain.Catalog.Materials.Entities;
using MM.Domain.Catalog.Products.Entities;
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
    public DbSet<Material> Materials { get; set; }
    public DbSet<MaterialCategory> MaterialCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
}