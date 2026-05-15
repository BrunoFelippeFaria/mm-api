using MM.Application.Sales.Customers.Dtos;

namespace MM.Application.Sales.Customers.Interfaces;

public interface ICustomerDao
{
    public Task<IReadOnlyList<CustomerDto>> GetAll();
}