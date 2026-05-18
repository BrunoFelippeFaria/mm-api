using MM.Domain.Shared.Base;

namespace MM.Domain.Sales.Customers.Entities;

public class Customer : Entity
{
    public required string Name { get; set; }
    public int? GroupId { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Notes { get; set; }

    public CustomerGroup Group { get; set; } = null!;
}