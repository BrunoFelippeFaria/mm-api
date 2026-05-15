using Mediator;

using MM.Application.Sales.Customers.Dtos;

namespace MM.Application.Sales.Customers.Queries.GetById;

public record GetCustomerByIdQuery(int Id) : IRequest<CustomerDto>;