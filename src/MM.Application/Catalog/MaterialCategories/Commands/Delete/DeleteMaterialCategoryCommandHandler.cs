using Mediator;

using MM.Application.Catalog.MaterialCategories.Exceptions;
using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Domain.Shared.Exceptions;

namespace MM.Application.Catalog.MaterialCategories.Commands.Delete;

public class DeleteMaterialCategoryCommandHandler(
    IMaterialCategoryRepository materialCategoryRepository,
    IMaterialCategoryDao materialCategoryDao
)
    : IRequestHandler<DeleteMaterialCategoryCommand, Unit>
{
    private readonly IMaterialCategoryRepository _materialCategoryRepository = materialCategoryRepository;
    private readonly IMaterialCategoryDao _materialCategoryDao = materialCategoryDao;

    public async ValueTask<Unit> Handle(DeleteMaterialCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _materialCategoryRepository.GetById(request.Id)
            ?? throw new MaterialCategoryNotFoundException(request.Id);

        if (await _materialCategoryDao.HasMaterials(request.Id))
        {
            if (!request.Force)
                throw new MaterialCategoryHasMaterialsException(request.Id);

            await _materialCategoryDao.RemoveCategoryFromMaterials(request.Id);
        }

        category.Delete();

        return Unit.Value;
    }
}