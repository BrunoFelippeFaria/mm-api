namespace MM.Application.Auth.Dtos;

public record UserAuthDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Hash { get; set; }
}