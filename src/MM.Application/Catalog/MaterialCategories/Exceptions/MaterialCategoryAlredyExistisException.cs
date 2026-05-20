using MM.Domain.Shared.Exceptions;

namespace MM.Application.Catalog.MaterialCategories.Exceptions;

public class MaterialCategoryAlreadyExistsException(string description) 
    : ConflictException($"categoria '{description}' já existe")
{
    public override string Code => "material_category_already_exists";
}