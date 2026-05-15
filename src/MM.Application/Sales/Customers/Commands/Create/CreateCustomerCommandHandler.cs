
using Mediator;

using MM.Application.Sales.Customers.Interfaces;
using MM.Domain.Sales.Customers.Entities;

namespace MM.Application.Sales.Customers.Commands.Create;

public class CreateCustomerCommandHandler (ICustomerRepository customerRepository)
    : IRequestHandler<CreateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public ValueTask<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Name = request.Name
        };

        _customerRepository.Create(customer);

        return ValueTask.FromResult(Unit.Value);
    }
}