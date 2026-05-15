using Mediator;

using MM.Application.Shared.Interfaces;

namespace MM.Application.Sales.Customers.Commands.Create;

public record CreateCustomerCommand : IRequest<Unit>, ITranslacionalRequest
{
    public required string Name { get; set; }
}