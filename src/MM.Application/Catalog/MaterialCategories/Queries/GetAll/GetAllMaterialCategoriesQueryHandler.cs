
using Mediator;

using MM.Application.Catalog.MaterialCategories.Dtos;
using MM.Application.Catalog.MaterialCategories.Interfaces;

namespace MM.Application.Catalog.MaterialCategories.Queries.GetAll;

public class GetAllMaterialCategoriesQueryHandler(IMaterialCategoryDao materialCategoryDao)
    : IRequestHandler<GetAllMaterialCategoriesQuery, IEnumerable<MaterialCategoryDto>>
{
    private readonly IMaterialCategoryDao _materialCategoryDao = materialCategoryDao;

    public async ValueTask<IEnumerable<MaterialCategoryDto>> Handle(GetAllMaterialCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _materialCategoryDao.GetAll();
    }
}