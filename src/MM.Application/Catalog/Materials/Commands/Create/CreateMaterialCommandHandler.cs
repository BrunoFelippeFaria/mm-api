using Mediator;

using MM.Application.Catalog.Materials.Exceptions;
using MM.Application.Catalog.Materials.Interfaces;
using MM.Domain.Catalog.Materials.Entities;
using MM.Domain.Shared.Extensions;

namespace MM.Application.Catalog.Materials.Commands.Create;

public class CreateMaterialCommandHandler(IMaterialRepository materialRepository, IMaterialsDao dao)
    : IRequestHandler<CreateMaterialCommand, Unit>
{
    private readonly IMaterialRepository _materialRepository = materialRepository;
    private readonly IMaterialsDao _dao = dao;

    public async ValueTask<Unit> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {
        string normalizedDescription = request.Description.NormalizeSpaces();

        if (await _dao.DescriptionExists(normalizedDescription))
            throw new MaterialAlredyExistsException(normalizedDescription);

        var material = new Material
        {
            Description = normalizedDescription,
            Unit = request.Unit,
            CategoryId = request.CategoryId,
            Notes = request.Notes,
            SafetyStock = request.SafetyStock
        };

        _materialRepository.Create(material);

        return Unit.Value;
    }
}