using Mediator;

using MM.Application.Catalog.Materials.Interfaces;
using MM.Domain.Catalog.Materials.Entities;

namespace MM.Application.Catalog.Materials.Commands.Create;

class CreateMaterialCommandHandler (IMaterialRepository materialRepository)
    : IRequestHandler<CreateMaterialCommand, Unit>
{
    private readonly IMaterialRepository _materialRepository = materialRepository;

    public ValueTask<Unit> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = new Material
        {
            Description = request.Description,
            Unit = request.Unit,
            CategoryId = request.CategoryId,
            Notes = request.Notes,
            SafetyStock = request.SafetyStock
        };

        _materialRepository.Create(material);

        return ValueTask.FromResult(Unit.Value);
    }
}