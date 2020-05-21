using FluentValidation;

namespace Application.Categories.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(e => e.Description).NotEmpty().MaximumLength(100);
        }
    }
}
