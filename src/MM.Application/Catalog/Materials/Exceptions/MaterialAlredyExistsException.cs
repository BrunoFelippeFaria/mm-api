using MM.Domain.Shared.Exceptions;

namespace MM.Application.Catalog.Materials.Exceptions;

public class MaterialAlredyExistsException(string description) 
    : ConflictException($"Material '{description}' já existe.")
{
    public override string Code => "material_already_exists";
}