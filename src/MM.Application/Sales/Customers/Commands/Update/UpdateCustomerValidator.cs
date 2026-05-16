using FluentValidation;

namespace MM.Application.Sales.Customers.Commands.Update;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerValidator()
    {
        RuleFor(x => x.Name)
            .Length(3, 60);
    }
}