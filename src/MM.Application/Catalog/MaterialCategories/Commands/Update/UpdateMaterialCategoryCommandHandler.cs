using Mediator;

using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Domain.Shared.Exceptions;

namespace MM.Application.Catalog.MaterialCategories.Commands.Update;

public class UpdateMaterialCategoryCommandHandler (IMaterialCategoryRepository materialCategoryRepository)
    : IRequestHandler<UpdateMaterialCategoryCommand, Unit>
{
    private readonly IMaterialCategoryRepository _materialCategoryRepository = materialCategoryRepository;

    public async ValueTask<Unit> Handle(UpdateMaterialCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _materialCategoryRepository.GetById(request.Id)
            ?? throw new NotFoundException($"category {request.Id} does not exist");

        category.Description = request.Description;

        return Unit.Value;
    }
}