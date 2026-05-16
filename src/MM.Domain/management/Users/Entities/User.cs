using MM.Domain.Shared.Base;

namespace MM.Domain.Management.Users.Entities;

public class User : Entity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string Hash { get; set; } = string.Empty;
}