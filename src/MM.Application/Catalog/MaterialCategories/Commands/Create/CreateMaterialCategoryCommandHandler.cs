
using Mediator;

using MM.Application.Catalog.MaterialCategories.Exceptions;
using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Domain.Catalog.Materials.Entities;
using MM.Domain.Shared.Extensions;

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
        string normalizedDescription = request.Description.NormalizeSpaces();

        if (await _materialCategoryDao.DescriptionExists(normalizedDescription))
            throw new MaterialCategoryAlreadyExistsException(normalizedDescription);

        var category = new MaterialCategory
        {
            Description = normalizedDescription
        };

        _materialCategoryRepository.Create(category);

        return Unit.Value;
    }
}