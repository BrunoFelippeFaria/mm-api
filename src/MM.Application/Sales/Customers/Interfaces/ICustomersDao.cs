using MM.Application.Sales.Customers.Dtos;

namespace MM.Application.Sales.Customers.Interfaces;

public interface ICustomersDao
{
    Task<IReadOnlyList<CustomerDto>> GetAll();
    Task<CustomerDto?> GetById(int id);
}