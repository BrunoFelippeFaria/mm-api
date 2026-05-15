namespace MM.Application.Shared.Interfaces;

public interface IUnityOfWork
{
    public Task CommitAsync();
}