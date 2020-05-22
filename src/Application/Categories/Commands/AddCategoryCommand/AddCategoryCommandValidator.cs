using FluentValidation;

namespace Application.Categories.Commands.AddCategoryCommand
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(e => e.Description).NotEmpty().MaximumLength(100);
        }
    }
}
