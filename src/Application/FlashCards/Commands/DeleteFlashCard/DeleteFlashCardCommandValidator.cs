using FluentValidation;

namespace Application.FlashCards.Commands.DeleteFlashCard
{
    public class DeleteFlashCardCommandValidator:AbstractValidator<DeleteFlashCardCommand>
    {
        public DeleteFlashCardCommandValidator()
        {
            RuleFor(f => f.Id).NotEmpty();
        }
    }
}
