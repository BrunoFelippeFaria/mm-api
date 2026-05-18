using MM.Domain.Shared.Base;

namespace MM.Domain.Catalog.Products.Entities;

public class KitItem : Entity
{
    public int KitId { get; set; }
    public int ProductId { get; set; }
    public decimal Quantity { get; set; }

    public Product Kit { get; set; } = null!;
    public Product Product { get; set; } = null!;
}