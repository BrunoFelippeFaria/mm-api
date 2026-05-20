
using Mediator;

using MM.Application.Sales.Customers.Exceptions;
using MM.Application.Sales.Customers.Interfaces;
using MM.Domain.Shared.Exceptions;

namespace MM.Application.Sales.Customers.Commands.Update;

public class UpdateCustomerCommandHandler(
    ICustomerRepository customerRepository
) 
    : IRequestHandler<UpdateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async ValueTask<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(request.Id)
            ?? throw new CustomerNotFoundException(request.Id);

        customer.Name = request.Name;

        return Unit.Value;
    }
}