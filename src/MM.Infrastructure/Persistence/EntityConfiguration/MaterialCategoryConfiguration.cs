using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MM.Domain.Catalog.Materials.Entities;

namespace MM.Infrastructure.Persistence.EntityConfiguration;

public class MaterialCategoryConfiguration : IEntityTypeConfiguration<MaterialCategory>
{
    public void Configure(EntityTypeBuilder<MaterialCategory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .HasMaxLength(30);

        builder.HasQueryFilter(x => x.IsDeleted == false);
    }
}