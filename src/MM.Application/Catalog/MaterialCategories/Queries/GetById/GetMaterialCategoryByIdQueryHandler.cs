
using Mediator;

using MM.Application.Catalog.MaterialCategories.Dtos;
using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Domain.Shared.Exceptions;

namespace MM.Application.Catalog.MaterialCategories.Queries.GetById;

public class GetMaterialCategoryByIdQueryHandler (IMaterialCategoryDao materialCategoryDao)
    : IRequestHandler<GetMaterialCategoryByIdQuery, MaterialCategoryDto>
{
    private readonly IMaterialCategoryDao _materialCategoryDao = materialCategoryDao;

    public async ValueTask<MaterialCategoryDto> Handle(GetMaterialCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _materialCategoryDao.GetById(request.Id)
            ?? throw new NotFoundException($"category {request.Id} does not exist");

        return category;
    }
}