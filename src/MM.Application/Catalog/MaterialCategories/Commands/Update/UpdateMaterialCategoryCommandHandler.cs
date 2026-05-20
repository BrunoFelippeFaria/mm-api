using Mediator;

using MM.Application.Catalog.MaterialCategories.Exceptions;
using MM.Application.Catalog.MaterialCategories.Interfaces;

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
        if (await _materialCategoryDao.DescriptionExists(request.Description, request.Id))
            throw new MaterialCategoryAlreadyExistsException(request.Description);

        var category = await _materialCategoryRepository.GetById(request.Id)
            ?? throw new MaterialCategoryNotFoundException(request.Id);

        category.Description = request.Description;

        return Unit.Value;
    }
}