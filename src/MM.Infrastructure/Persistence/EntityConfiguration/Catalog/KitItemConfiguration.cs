using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MM.Domain.Catalog.Products.Entities;

namespace MM.Infrastructure.Persistence.EntityConfiguration.Catalog;

public class KitItemConfiguration : IEntityTypeConfiguration<KitItem>
{
    public void Configure(EntityTypeBuilder<KitItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => x.IsDeleted == false);
    }
}