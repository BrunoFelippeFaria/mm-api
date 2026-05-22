using Mediator;

using MM.Application.Shared.Interfaces;

namespace MM.Application.Catalog.MaterialCategories.Commands.Delete;

public record DeleteMaterialCategoryCommand(int Id) : IRequest<Unit>, ITranslacionalRequest
{
    public bool Force { get; set; } = false;
}