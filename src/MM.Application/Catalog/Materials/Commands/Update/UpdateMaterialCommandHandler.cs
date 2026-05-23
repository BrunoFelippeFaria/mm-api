
using Mediator;

using MM.Application.Catalog.Materials.Exceptions;
using MM.Application.Catalog.Materials.Interfaces;
using MM.Application.Shared.Interfaces;
using MM.Domain.Catalog.Shared.Enums;
using MM.Domain.Shared.Extensions;

namespace MM.Application.Catalog.Materials.Commands.Update;

public class UpdateMaterialCommandHandler (IMaterialRepository materialRepository, IMaterialsDao materialsDao)
    : IRequestHandler<UpdateMaterialCommand, Unit>
{
    private readonly IMaterialRepository _materialRepository = materialRepository;
    private readonly IMaterialsDao _materialsDao = materialsDao;

    public async ValueTask<Unit> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
    {
        string normalizedDescription = request.Description.NormalizeSpaces();

        var material = await _materialRepository.GetById(request.Id)
            ?? throw new MaterialNotFoundException(request.Id);

        if (await _materialsDao.DescriptionExists(normalizedDescription, request.Id))
            throw new MaterialAlredyExistsException(normalizedDescription);

        material.Description = normalizedDescription;
        material.Unit = request.Unit;
        material.CategoryId = request.CategoryId;
        material.Notes = request.Notes;
        material.SafetyStock = request.SafetyStock;

        return Unit.Value;
    }
}