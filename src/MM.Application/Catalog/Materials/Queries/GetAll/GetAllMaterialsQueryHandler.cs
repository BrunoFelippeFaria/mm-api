
using Mediator;

using MM.Application.Catalog.Materials.Dtos;
using MM.Application.Catalog.Materials.Interfaces;

namespace MM.Application.Catalog.Materials.Queries.GetAll;

class GetAllMaterialsQueryHandler(IMaterialsDao materialsDao)
    : IRequestHandler<GetAllMaterialsQuery, IEnumerable<MaterialListDto>>
{
    private readonly IMaterialsDao _materialsDao = materialsDao;

    public async ValueTask<IEnumerable<MaterialListDto>> Handle(GetAllMaterialsQuery request, CancellationToken cancellationToken)
    {
        var materials = await _materialsDao.GetAll();
        return materials;
    }
}