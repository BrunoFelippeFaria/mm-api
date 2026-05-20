
using Mediator;

using MM.Application.Catalog.MaterialCategories.Exceptions;
using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Domain.Catalog.Materials.Entities;

namespace MM.Application.Catalog.MaterialCategories.Commands.Create;

public class CreateMaterialCategoryCommandHandler(
    IMaterialCategoryRepository materialCategoryRepository,
    IMaterialCategoryDao materialCategoryDao
)
    : IRequestHandler<CreateMaterialCategoryCommand, Unit>
{
    private readonly IMaterialCategoryRepository _materialCategoryRepository = materialCategoryRepository;
    private readonly IMaterialCategoryDao _materialCategoryDao = materialCategoryDao;

    public async ValueTask<Unit> Handle(CreateMaterialCategoryCommand request, CancellationToken cancellationToken)
    {
        if (await _materialCategoryDao.DescriptionExists(request.Description))
            throw new MaterialCategoryAlreadyExistsException(request.Description);

        var category = new MaterialCategory
        {
            Description = request.Description
        };

        _materialCategoryRepository.Create(category);

        return Unit.Value;
    }
}