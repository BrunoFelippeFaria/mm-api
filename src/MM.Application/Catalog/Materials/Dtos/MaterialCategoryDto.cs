namespace MM.Application.Catalog.Materials.Dtos;

public record MaterialCategoryDto
{
    public int Id { get; set; }
    public required string Description { get; set; }
}