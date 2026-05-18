using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MM.Domain.Catalog.Products.Entities;

namespace MM.Infrastructure.Persistence.EntityConfiguration.Catalog;

public class KitItemConfiguration : IEntityTypeConfiguration<KitItem>
{
    public void Configure(EntityTypeBuilder<KitItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Kit)
               .WithMany(x => x.KitItems)
               .HasForeignKey(x => x.KitId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Product)
               .WithMany()
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => x.IsDeleted == false);
    }
}