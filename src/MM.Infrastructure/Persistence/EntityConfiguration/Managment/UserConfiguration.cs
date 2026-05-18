using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MM.Domain.Management.Users.Entities;

namespace MM.Infrastructure.Persistence.EntityConfiguration.Managment;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(60);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.HasQueryFilter(x => x.IsDeleted == false);
    }
}