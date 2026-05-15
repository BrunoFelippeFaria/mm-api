using MM.Domain.Shared.Base;

namespace MM.Domain.Sales.Customers.Entities;

public class Customer : Entity
{
    public required string Name { get; set; }
}