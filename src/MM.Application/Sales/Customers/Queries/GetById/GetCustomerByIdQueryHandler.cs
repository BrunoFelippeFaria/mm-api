using Mediator;

using MM.Application.Sales.Customers.Dtos;
using MM.Application.Sales.Customers.Exceptions;
using MM.Application.Sales.Customers.Interfaces;
using MM.Domain.Shared.Exceptions;

namespace MM.Application.Sales.Customers.Queries.GetById;

public class GetCustomerByIdQueryHandler(ICustomersDao customerDao)
    : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly ICustomersDao _customerDao = customerDao;

    public async ValueTask<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerDao.GetById(request.Id)
            ?? throw new CustomerNotFoundException(request.Id);

        return customer;
    }
}