using MM.Domain.Shared.Exceptions;

namespace MM.Application.Catalog.MaterialCategories.Exceptions;

public class MaterialCategoryNotFoundException(int id)
    : NotFoundException($"Categoria de Material {id} não encontrada")
{
    public override string Code => "material_category_not_found";
}