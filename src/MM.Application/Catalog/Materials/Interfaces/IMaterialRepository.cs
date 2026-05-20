using MM.Domain.Catalog.Materials.Entities;

namespace MM.Application.Catalog.Materials.Interfaces;

public interface IMaterialRepository
{
    Task<Material?> GetById(int id);
    void Create(Material material);
}