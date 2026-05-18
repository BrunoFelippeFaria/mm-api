using MM.Domain.Shared.Base;

namespace MM.Domain.Sales.Customers.Entities;

public class CustomerGroup : Entity
{
    public required string Description { get; set; }
}