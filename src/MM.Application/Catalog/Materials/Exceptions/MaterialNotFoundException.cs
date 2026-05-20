using MM.Domain.Shared.Exceptions;

namespace MM.Application.Catalog.Materials.Exceptions;

public class MaterialNotFoundException(int id)
    : NotFoundException($"Material {id} não encontrado")
{
    public override string Code => "material_not_found";
}