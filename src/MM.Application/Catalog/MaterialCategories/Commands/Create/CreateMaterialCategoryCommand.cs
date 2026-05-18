using Mediator;

using MM.Application.Shared.Interfaces;

namespace MM.Application.Catalog.MaterialCategories.Commands.Create;

public record CreateMaterialCategoryCommand : IRequest<Unit>, ITranslacionalRequest
{
    public required string Description { get; set; }    
}