using MM.Application.Catalog.MaterialCategories.Dtos;

namespace MM.Application.Catalog.MaterialCategories.Interfaces;

public interface IMaterialCategoryDao
{
    Task<IEnumerable<MaterialCategoryDto>> GetAll();
    Task<MaterialCategoryDto?> GetById(int id);
}