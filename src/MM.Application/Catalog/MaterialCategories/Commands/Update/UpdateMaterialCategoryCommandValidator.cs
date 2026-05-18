using FluentValidation;

namespace MM.Application.Catalog.MaterialCategories.Commands.Update;

public class UpdateMaterialCategoryCommandValidator : AbstractValidator<UpdateMaterialCategoryCommand>
{
    public UpdateMaterialCategoryCommandValidator()
    {
        RuleFor(x => x.Description)
            .Length(3, 30)
            .NotEmpty();
    }
}