
using Mediator;

using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Domain.Shared.Exceptions;

namespace MM.Application.Catalog.MaterialCategories.Commands.Delete;

public class DeleteMaterialCategoryCommandHandler (IMaterialCategoryRepository materialCategoryRepository)
    : IRequestHandler<DeleteMaterialCategoryCommand, Unit>
{
    private readonly IMaterialCategoryRepository _materialCategoryRepository = materialCategoryRepository;

    public async ValueTask<Unit> Handle(DeleteMaterialCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _materialCategoryRepository.GetById(request.Id)
            ?? throw new NotFoundException($"category {request.Id} does not exist");

        category.Delete();
        
        return Unit.Value;
    }
}