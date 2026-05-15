using Mediator;

using MM.Application.Shared.Interfaces;

namespace MM.Application.Sales.Customers.Commands.Delete;

public record DeleteCustomerCommand(int Id) 
    : IRequest<Unit>, ITranslacionalRequest;
