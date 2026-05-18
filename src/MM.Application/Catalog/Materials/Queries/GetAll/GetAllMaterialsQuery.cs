using Mediator;

using MM.Application.Catalog.Materials.Dtos;

namespace MM.Application.Catalog.Materials.Queries.GetAll;

public record GetAllMaterialsQuery : IRequest<IEnumerable<MaterialListDto>>;
