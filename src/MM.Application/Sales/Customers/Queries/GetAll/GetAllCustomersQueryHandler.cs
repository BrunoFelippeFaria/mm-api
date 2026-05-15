
using Mediator;

using MM.Application.Sales.Customers.Dtos;
using MM.Application.Sales.Customers.Interfaces;

namespace MM.Application.Sales.Customers.Queries.GetAll;

public class GetAllCustomersQueryHandler (ICustomerDao customerDao)
    : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    private readonly ICustomerDao _customerDao = customerDao;

    public async ValueTask<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerDao.GetAll();
        return customers;
    }
}