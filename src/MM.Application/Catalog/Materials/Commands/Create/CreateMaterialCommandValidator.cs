using FluentValidation;

namespace MM.Application.Catalog.Materials.Commands.Create;

public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialCommandValidator()
    {
        RuleFor(x => x.Description)
            .Length(3, 60)
            .NotEmpty();    
    }
}