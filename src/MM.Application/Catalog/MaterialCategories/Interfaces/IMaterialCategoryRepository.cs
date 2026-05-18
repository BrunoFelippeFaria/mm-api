using MM.Domain.Catalog.Materials.Entities;

namespace MM.Application.Catalog.MaterialCategories.Interfaces;

public interface IMaterialCategoryRepository
{
    Task<MaterialCategory?> GetById(int id);
    void Create(MaterialCategory category);
}