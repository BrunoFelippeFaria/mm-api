
using Mediator;

using MM.Application.Sales.Customers.Interfaces;
using MM.Domain.Shared.Exceptions;

namespace MM.Application.Sales.Customers.Commands.Delete;

public class DeleteCustomerCommandHandler (ICustomerRepository customerRepository)
    : IRequestHandler<DeleteCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async ValueTask<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(request.Id)
            ?? throw new NotFoundException($"customer {request.Id} does not exist");

        customer.Delete();
        return Unit.Value;
    }
}