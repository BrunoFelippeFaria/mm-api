using System.Threading.Tasks;

using MM.Application.Shared.Interfaces;
using MM.Infrastructure.Persistence.Context;

namespace MM.Infrastructure.Persistence.UnityOfWork;

public class UnityOfWork (AppDbContext context) : IUnityOfWork
{
    private readonly AppDbContext _context = context;

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}