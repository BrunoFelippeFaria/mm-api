using MM.Domain.Catalog.Products.Enums;
using MM.Domain.Catalog.Shared.Enums;
using MM.Domain.Shared.Base;

namespace MM.Domain.Catalog.Products.Entities;

public class Product : Entity
{
    public required string Description { get; set; }
    public required UnitOfMeasure Unit { get; set; }
    public required ProductType Type { get; set; }
    public int CategoryId { get; set; }
    public string? Notes { get; set; }
    public int SafetyStock { get; set; }
    public decimal? CostPrice { get; set; }
    public decimal SalePrice { get; set; }

    public ProductCategory Category { get; set; } = null!;
    public ICollection<ProductRecipe> Recipe { get; set; } = [];
    public ICollection<KitItem> KitItems { get; set; } = [];
}