using FluentValidation;

namespace MM.Application.Catalog.MaterialCategories.Commands.Create;

public class CreateMaterialCategoryCommandValidator : AbstractValidator<CreateMaterialCategoryCommand>
{
    public CreateMaterialCategoryCommandValidator()
    {
        RuleFor(x => x.Description)
            .Length(3, 30)
            .NotEmpty();
    }
}