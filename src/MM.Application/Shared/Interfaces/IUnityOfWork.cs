namespace MM.Application.Shared.Interfaces;

public interface IUnityOfWork
{
    Task CommitAsync();
}