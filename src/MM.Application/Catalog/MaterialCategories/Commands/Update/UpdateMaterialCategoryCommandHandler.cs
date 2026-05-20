using Mediator;

using MM.Application.Catalog.MaterialCategories.Exceptions;
using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Domain.Shared.Extensions;

namespace MM.Application.Catalog.MaterialCategories.Commands.Update;

public class UpdateMaterialCategoryCommandHandler(
    IMaterialCategoryRepository materialCategoryRepository,
    IMaterialCategoryDao materialCategoryDao
)
    : IRequestHandler<UpdateMaterialCategoryCommand, Unit>
{
    private readonly IMaterialCategoryRepository _materialCategoryRepository = materialCategoryRepository;
    private readonly IMaterialCategoryDao _materialCategoryDao = materialCategoryDao;

    public async ValueTask<Unit> Handle(UpdateMaterialCategoryCommand request, CancellationToken cancellationToken)
    {
        string normalizedDescription = request.Description.NormalizeSpaces();

        if (await _materialCategoryDao.DescriptionExists(normalizedDescription, request.Id))
            throw new MaterialCategoryAlreadyExistsException(normalizedDescription);

        var category = await _materialCategoryRepository.GetById(request.Id)
            ?? throw new MaterialCategoryNotFoundException(request.Id);

        category.Description = normalizedDescription;

        return Unit.Value;
    }
}