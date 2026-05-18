using MM.Domain.Catalog.Materials.Entities;
using MM.Domain.Shared.Base;

namespace MM.Domain.Catalog.Products.Entities;

public class ProductRecipe : Entity
{
    public int ProductId { get; set; }
    public int MaterialId { get; set; }
    public decimal Quantity { get; set; }

    public Product Product { get; set; } = null!;
    public Material Material { get; set; } = null!;
}