using Mediator;

using MM.Application.Catalog.MaterialCategories.Exceptions;
using MM.Application.Catalog.MaterialCategories.Interfaces;

namespace MM.Application.Catalog.MaterialCategories.Commands.Delete;

public class DeleteMaterialCategoryCommandHandler(IMaterialCategoryRepository materialCategoryRepository)
    : IRequestHandler<DeleteMaterialCategoryCommand, Unit>
{
    private readonly IMaterialCategoryRepository _materialCategoryRepository = materialCategoryRepository;

    public async ValueTask<Unit> Handle(DeleteMaterialCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _materialCategoryRepository.GetById(request.Id)
            ?? throw new MaterialCategoryNotFoundException(request.Id);

        category.Delete();

        return Unit.Value;
    }
}