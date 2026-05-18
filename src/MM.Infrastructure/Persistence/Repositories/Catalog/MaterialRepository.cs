using System.Threading.Tasks;

using MM.Application.Catalog.Materials.Interfaces;
using MM.Domain.Catalog.Materials.Entities;
using MM.Infrastructure.Persistence.Context;

namespace MM.Infrastructure.Persistence.Repositories.Catalog;

public class MaterialRepository(AppDbContext context) : IMaterialRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Material?> GetById(int id)
    {
        return await _context.Materials
            .FindAsync(id);
    }
    
    public void Create(Material material)
    {
        _context.Materials.Add(material);
    }
}