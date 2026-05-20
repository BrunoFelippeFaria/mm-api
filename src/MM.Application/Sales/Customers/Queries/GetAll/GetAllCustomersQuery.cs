using Mediator;

using MM.Application.Sales.Customers.Dtos;

namespace MM.Application.Sales.Customers.Queries.GetAll;

public sealed record GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>;