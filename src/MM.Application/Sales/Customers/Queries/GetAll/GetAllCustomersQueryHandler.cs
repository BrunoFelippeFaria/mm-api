
using Mediator;

using MM.Application.Sales.Customers.Dtos;

namespace MM.Application.Sales.Customers.Queries.GetAll;

public sealed record GetAllCustomersQueryHandler
    : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    public ValueTask<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return ValueTask.FromResult(Enumerable.Empty<CustomerDto>());
    }
}