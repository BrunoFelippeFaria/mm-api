using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MM.Domain.Catalog.Products.Entities;

namespace MM.Infrastructure.Persistence.EntityConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .HasMaxLength(60);

        builder.HasQueryFilter(x => x.IsDeleted == false);
    }
}