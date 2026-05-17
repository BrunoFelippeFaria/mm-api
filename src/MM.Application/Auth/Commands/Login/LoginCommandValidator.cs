using System.ComponentModel.DataAnnotations;

using FluentValidation;

namespace MM.Application.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .Must(value => value == "admin" || new EmailAddressAttribute().IsValid(value));

        RuleFor(x => x.Password)
            .NotEmpty()
            .Length(4, 60);
    }
}