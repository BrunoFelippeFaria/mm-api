using Microsoft.EntityFrameworkCore;

using MM.Application.Catalog.MaterialCategories.Dtos;
using MM.Application.Catalog.Materials.Dtos;
using MM.Application.Catalog.Materials.Interfaces;
using MM.Infrastructure.Persistence.Context;

namespace MM.Infrastructure.Persistence.Daos.Catalog;

public class MaterialsDao(AppDbContext context) : IMaterialsDao
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<MaterialListDto>> GetAll()
    {
        return await _context.Materials
            .Select(m => new MaterialListDto
            {
                Id = m.Id,
                Description = m.Description,
            })
            .AsNoTracking()
            .ToArrayAsync();
    }

    public async Task<MaterialDto?> GetById(int id)
    {
        return await _context.Materials
            .Where(m => m.Id == id)
            .Select(m => new MaterialDto
            {
                Id = m.Id,
                Description = m.Description,
                Unit = m.Unit,
                LastBuyPrice = m.LastBuyPrice,
                SafetyStock = m.SafetyStock,
                Notes = m.Notes,

            Category = m.Category != null
                ? new MaterialCategoryDto
                {
                    Id = m.Category.Id,
                    Description = m.Category.Description
                }
                : null,
            })
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
}