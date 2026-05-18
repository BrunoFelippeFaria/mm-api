using MM.Application.Sales.Customers.Interfaces;
using MM.Domain.Sales.Customers.Entities;
using MM.Infrastructure.Persistence.Context;

namespace MM.Infrastructure.Persistence.Repositories.Sales;

public class CustomerRepository (AppDbContext context) : ICustomerRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Customer?> GetById(int id)
    {
        return await _context.Customers
            .FindAsync(id);
    }

    public void Create(Customer customer)
    {
        _context.Customers.Add(customer);
    }
}