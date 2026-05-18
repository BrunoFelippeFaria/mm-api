using Mediator;

using MM.Application.Catalog.MaterialCategories.Dtos;

namespace MM.Application.Catalog.MaterialCategories.Queries.GetAll;

public class GetAllMaterialCategoriesQuery : IRequest<IEnumerable<MaterialCategoryDto>>;