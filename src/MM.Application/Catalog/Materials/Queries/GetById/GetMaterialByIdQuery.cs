using Mediator;

using MM.Application.Catalog.Materials.Dtos;

namespace MM.Application.Catalog.Materials.Queries.GetById;

public record GetMaterialByIdQuery(int Id) : IRequest<MaterialDto>;