using FluentValidation;

namespace Application.Categories.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
        }
    }
}
