using MM.Application.Catalog.Materials.Dtos;

namespace MM.Application.Catalog.Materials.Interfaces;

public interface IMaterialsDao
{
    Task<IEnumerable<MaterialListDto>> GetAll();
    Task<MaterialDto?> GetById(int id);
    Task<bool> DescriptionExists(string description, int? ignoredId = null);
}