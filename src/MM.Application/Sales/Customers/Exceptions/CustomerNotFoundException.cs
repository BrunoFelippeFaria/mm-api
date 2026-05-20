using MM.Domain.Shared.Exceptions;

namespace MM.Application.Sales.Customers.Exceptions;

public class CustomerNotFoundException(int id) 
    : NotFoundException($"cliente {id} não encontrado")
{
    public override string Code => "customer_not_found";
}