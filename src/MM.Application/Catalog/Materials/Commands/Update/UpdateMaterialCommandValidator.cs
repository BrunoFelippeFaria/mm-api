using FluentValidation;

namespace MM.Application.Catalog.Materials.Commands.Update;

public class UpdateMaterialCommandValidator : AbstractValidator<UpdateMaterialCommand>
{
    public UpdateMaterialCommandValidator()
    {
        RuleFor(x => x.Description)
            .Length(3, 60)
            .NotEmpty();
    }
}