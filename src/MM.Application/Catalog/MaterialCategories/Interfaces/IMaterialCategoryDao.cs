using MM.Application.Catalog.MaterialCategories.Dtos;

namespace MM.Application.Catalog.MaterialCategories.Interfaces;

public interface IMaterialCategoryDao
{
    Task<IEnumerable<MaterialCategoryDto>> GetAll();
    Task<MaterialCategoryDto?> GetById(int id);
    Task<bool> DescriptionExists(string description, int? ignoredId = null);
    Task<bool> HasMaterials(int id);
    Task RemoveCategoryFromMaterials(int id);
}