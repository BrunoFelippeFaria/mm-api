using MM.Domain.Shared.Base;
using MM.Domain.Shared.Extensions;

namespace MM.Domain.Catalog.Materials.Entities;

public class MaterialCategory : Entity
{
    private string _description = string.Empty;

    public required string Description
    {
        get => _description;
        set => _description = value.NormalizeSpaces();
    }
}