using Mediator;

using MM.Application.Shared.Interfaces;

namespace MM.Application.Catalog.MaterialCategories.Commands.Update;

public record UpdateMaterialCategoryCommand(int Id) : IRequest<Unit>, ITranslacionalRequest
{
    public required string Description { get; set; }
}