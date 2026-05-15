using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MM.Application.Sales.Customers.Dtos;
using MM.Application.Sales.Customers.Interfaces;
using MM.Infrastructure.Persistence.Context;

namespace MM.Infrastructure.Persistence.Daos;

public class CustomersDao (AppDbContext context) : ICustomerDao
{
    private readonly AppDbContext _context = context;

    public async Task<IReadOnlyList<CustomerDto>> GetAll()
    {
        return await _context.Customers
            .Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }

    public async Task<CustomerDto> GetById(int id)
    {
        return await _context.Customers
            .Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .FirstAsync(c => c.Id == id);
    }
}