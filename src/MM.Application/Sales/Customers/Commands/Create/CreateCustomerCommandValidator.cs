using FluentValidation;

namespace MM.Application.Sales.Customers.Commands.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(3, 60);
    }
}