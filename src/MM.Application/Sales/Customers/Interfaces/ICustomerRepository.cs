using MM.Domain.Sales.Customers.Entities;

namespace MM.Application.Sales.Customers.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetById(int id);
    void Create(Customer customer);
}