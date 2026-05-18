using Mediator;

using MM.Application.Catalog.MaterialCategories.Dtos;
using MM.Domain.Catalog.Materials.Entities;

namespace MM.Application.Catalog.MaterialCategories.Queries.GetById;

public record GetMaterialCategoryByIdQuery(int Id) : IRequest<MaterialCategoryDto>;
