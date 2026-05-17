using Microsoft.EntityFrameworkCore;

namespace MM.Infrastructure.Persistence.Seeds;

public interface ISeed
{
    public Task Seed();
}