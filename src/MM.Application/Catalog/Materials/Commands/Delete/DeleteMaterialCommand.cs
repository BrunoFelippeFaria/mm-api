using Mediator;

using MM.Application.Shared.Interfaces;

namespace MM.Application.Catalog.Materials.Commands.Delete;

public record DeleteMaterialCommand(int Id) : IRequest<Unit>, ITranslacionalRequest;
