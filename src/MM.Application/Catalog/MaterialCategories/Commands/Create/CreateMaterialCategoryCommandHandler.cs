
using Mediator;

using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Domain.Catalog.Materials.Entities;

namespace MM.Application.Catalog.MaterialCategories.Commands.Create;

public class CreateMaterialCategoryCommandHandler (IMaterialCategoryRepository materialCategoryRepository)
    : IRequestHandler<CreateMaterialCategoryCommand, Unit>
{
    private readonly IMaterialCategoryRepository _materialCategoryRepository = materialCategoryRepository;

    public ValueTask<Unit> Handle(CreateMaterialCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new MaterialCategory
        {
            Description = request.Description
        };

        _materialCategoryRepository.Create(category);

        return ValueTask.FromResult(Unit.Value);
    }
}