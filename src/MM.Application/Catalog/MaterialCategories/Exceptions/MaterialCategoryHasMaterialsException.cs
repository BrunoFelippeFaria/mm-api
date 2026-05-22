using MM.Domain.Shared.Exceptions;

namespace MM.Application.Catalog.MaterialCategories.Exceptions;

public class MaterialCategoryHasMaterialsException(int id)
    : ConflictException($"Não é possível excluir a categoria de material {id}, pois existem materiais vinculados a ela.")
{
    public override string Code => "material_category_has_materials";
}
