using MM.Domain.Shared.Base;

namespace MM.Domain.Catalog.Materials.Entities;

public class MaterialCategory : Entity
{
    public required string Description { get; set; }
}