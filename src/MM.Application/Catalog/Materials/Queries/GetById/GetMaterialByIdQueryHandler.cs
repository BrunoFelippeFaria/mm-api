using Mediator;

using MM.Application.Catalog.Materials.Dtos;
using MM.Application.Catalog.Materials.Interfaces;
using MM.Domain.Shared.Exceptions;

namespace MM.Application.Catalog.Materials.Queries.GetById;

public class GetMaterialByIdQueryHandler (IMaterialsDao materialsDao)
    : IRequestHandler<GetMaterialByIdQuery, MaterialDto>
{
    private readonly IMaterialsDao _materialsDao = materialsDao;

    public async ValueTask<MaterialDto> Handle(GetMaterialByIdQuery request, CancellationToken cancellationToken)
    {
        var material = await _materialsDao.GetById(request.Id)
            ?? throw new NotFoundException($"Material {request.Id} does not exist");

        return material;
    }
}