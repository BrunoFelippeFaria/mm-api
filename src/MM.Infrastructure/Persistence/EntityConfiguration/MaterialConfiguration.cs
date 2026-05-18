using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MM.Domain.Catalog.Materials.Entities;

namespace MM.Infrastructure.Persistence.EntityConfiguration;

public class MaterialConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .HasMaxLength(60);

        builder.HasQueryFilter(x => x.IsDeleted == false);
    }
}