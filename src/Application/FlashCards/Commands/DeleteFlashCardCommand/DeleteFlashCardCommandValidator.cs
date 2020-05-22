using FluentValidation;

namespace Application.FlashCards.Commands.DeleteFlashCardCommand
{
    public class DeleteFlashCardCommandValidator : AbstractValidator<DeleteFlashCardCommand>
    {
        public DeleteFlashCardCommandValidator()
        {
            RuleFor(f => f.Id).NotEmpty();
        }
    }
}
