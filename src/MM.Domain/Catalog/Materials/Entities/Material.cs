using MM.Domain.Catalog.Shared.Enums;
using MM.Domain.Shared.Base;

namespace MM.Domain.Catalog.Materials.Entities;

public class Material : Entity
{
    public required string Description { get; set; }
    public required UnitOfMeasure Unit { get; set; }
    public int? CategoryId { get; set; }
    public string? Notes { get; set; }
    public decimal? LastBuyPrice { get; set; }
    public int SafetyStock { get; set; }

    public MaterialCategory? Category { get; set; }
}