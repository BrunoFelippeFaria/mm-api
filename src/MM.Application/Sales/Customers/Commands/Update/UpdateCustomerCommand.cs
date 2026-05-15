using Mediator;

using MM.Application.Shared.Interfaces;

namespace MM.Application.Sales.Customers.Commands.Update;

public record UpdateCustomerCommand(int Id) : IRequest<Unit>, ITranslacionalRequest
{
    public required string Name { get; set; }
}