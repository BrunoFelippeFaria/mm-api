
using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Domain.Catalog.Materials.Entities;
using MM.Infrastructure.Persistence.Context;

namespace MM.Infrastructure.Persistence.Repositories.Catalog;

public class MaterialCategoryRepository(AppDbContext context) : IMaterialCategoryRepository
{
    private readonly AppDbContext _context = context;

    public void Create(MaterialCategory category)
    {
        _context.MaterialCategories.Add(category);
    }

    public async Task<MaterialCategory?> GetById(int id)
    {
        return await _context.MaterialCategories.FindAsync(id);
    }
}