using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MM.Domain.Sales.Customers.Entities;

namespace MM.Infrastructure.Persistence.EntityConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(60);

        builder.HasQueryFilter(x => x.IsDeleted == false);
    }
}