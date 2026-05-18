using MM.Domain.Shared.Base;

namespace MM.Domain.Catalog.Products.Entities;

public class ProductCategory : Entity
{
    public required string Description { get; set; }
}