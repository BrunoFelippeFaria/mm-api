using Mediator;

using MM.Application.Shared.Interfaces;
using MM.Domain.Catalog.Shared.Enums;

namespace MM.Application.Catalog.Materials.Commands.Create;

public record CreateMaterialCommand : IRequest<Unit>, ITranslacionalRequest
{
    public required string Description { get; set; }
    public required UnitOfMeasure Unit { get; set; }
    public int CategoryId { get; set; }
    public string? Notes { get; set; }
    public int SafetyStock { get; set; }
}