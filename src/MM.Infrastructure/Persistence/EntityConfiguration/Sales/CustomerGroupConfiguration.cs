using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MM.Domain.Sales.Customers.Entities;

namespace MM.Infrastructure.Persistence.EntityConfiguration.Sales;

public class CustomerGroupConfiguration : IEntityTypeConfiguration<CustomerGroup>
{
    public void Configure(EntityTypeBuilder<CustomerGroup> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .HasMaxLength(30);

        builder.HasQueryFilter(x => x.IsDeleted == false);
    }
}