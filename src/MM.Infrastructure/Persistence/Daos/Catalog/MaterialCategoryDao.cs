
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MM.Application.Catalog.MaterialCategories.Dtos;
using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Infrastructure.Extensions;
using MM.Infrastructure.Persistence.Context;

namespace MM.Infrastructure.Persistence.Daos.Catalog;

public class MaterialCategoryDao(AppDbContext context) : IMaterialCategoryDao
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<MaterialCategoryDto>> GetAll()
    {
        return await _context.MaterialCategories
            .Select(m => new MaterialCategoryDto
            {
                Id = m.Id,
                Description = m.Description,
            })
            .ToArrayAsync();
    }

    public async Task<MaterialCategoryDto?> GetById(int id)
    {
        return await _context.MaterialCategories
            .Select(m => new MaterialCategoryDto
            {
                Id = m.Id,
                Description = m.Description,
            })
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<bool> DescriptionExists(string description, int? ignoredId=null)
    {
        return await _context.MaterialCategories
            .WhereIf(ignoredId.HasValue, m => m.Id != ignoredId)
            .AnyAsync(m => m.Description == description);
    }
}