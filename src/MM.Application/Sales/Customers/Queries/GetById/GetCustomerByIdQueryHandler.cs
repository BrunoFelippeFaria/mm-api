using Mediator;

using MM.Application.Sales.Customers.Dtos;
using MM.Application.Sales.Customers.Interfaces;

namespace MM.Application.Sales.Customers.Queries.GetById;

public class GetCustomerByIdQueryHandler(ICustomersDao customerDao) 
    : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly ICustomersDao _customerDao = customerDao;

    public async ValueTask<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerDao.GetById(request.Id);
        return customer; 
    }
}