
using Mediator;

using MM.Application.Catalog.Materials.Exceptions;
using MM.Application.Catalog.Materials.Interfaces;

namespace MM.Application.Catalog.Materials.Commands.Delete;

public class DeleteMaterialCommandHandler (IMaterialRepository materialRepository)
    : IRequestHandler<DeleteMaterialCommand, Unit>
{
    private readonly IMaterialRepository _materialRepository = materialRepository;

    public async ValueTask<Unit> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await _materialRepository.GetById(request.Id)
            ?? throw new MaterialNotFoundException(request.Id);

        material.Delete();

        return Unit.Value;   
    }
}