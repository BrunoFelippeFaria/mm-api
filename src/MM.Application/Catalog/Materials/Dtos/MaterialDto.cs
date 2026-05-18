namespace MM.Application.Catalog.Materials.Dtos;

public record MaterialDto
{
    public required string Description { get; set; }
    public string? Notes { get; set; }
    public decimal? LastBuyPrice { get; set; }
    public int SafetyStock { get; set; }
}