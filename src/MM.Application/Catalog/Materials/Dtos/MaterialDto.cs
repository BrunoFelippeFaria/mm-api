using MM.Domain.Catalog.Shared.Enums;

namespace MM.Application.Catalog.Materials.Dtos;

public record MaterialDto
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public required UnitOfMeasure Unit { get; set; }
    public required MaterialCategoryDto Category { get; set; }
    public string? Notes { get; set; }
    public decimal? LastBuyPrice { get; set; }
    public int SafetyStock { get; set; }
}