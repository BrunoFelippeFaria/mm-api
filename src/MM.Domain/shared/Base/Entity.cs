namespace MM.Domain.Shared.Base;

public abstract class Entity
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public bool IsDeleted { get; private set; } = false;
    
    public void Delete() => IsDeleted = true;
}