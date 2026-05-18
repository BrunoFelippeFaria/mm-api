namespace MM.Application.Catalog.MaterialCategories.Dtos;

public record MaterialCategoryDto
{
    public int Id { get; set; }
    public required string Description { get; set; }
}