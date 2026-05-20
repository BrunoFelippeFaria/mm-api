using Mediator;

using MM.Application.Catalog.MaterialCategories.Dtos;
using MM.Application.Catalog.MaterialCategories.Exceptions;
using MM.Application.Catalog.MaterialCategories.Interfaces;

namespace MM.Application.Catalog.MaterialCategories.Queries.GetById;

public class GetMaterialCategoryByIdQueryHandler (IMaterialCategoryDao materialCategoryDao)
    : IRequestHandler<GetMaterialCategoryByIdQuery, MaterialCategoryDto>
{
    private readonly IMaterialCategoryDao _materialCategoryDao = materialCategoryDao;

    public async ValueTask<MaterialCategoryDto> Handle(GetMaterialCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _materialCategoryDao.GetById(request.Id)
            ?? throw new MaterialCategoryNotFoundException(request.Id);

        return category;
    }
}