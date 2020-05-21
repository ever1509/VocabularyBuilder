using FluentValidation;

namespace Application.FlashCards.Commands.UpdateFlashCard
{
    public class UpdateFlashCardCommandValidator:AbstractValidator<UpdateFlashCardCommand>
    {
        public UpdateFlashCardCommandValidator()
        {
            RuleFor(f => f.Id).NotEmpty();
            RuleFor(f => f.Category).NotEmpty();
            RuleFor(f => f.TypeCard).NotEmpty();
            RuleFor(f => f.MainWord).NotEmpty().MaximumLength(50);
            RuleFor(f => f.Example).MaximumLength(1000);
            RuleFor(f => f.Meaning).NotEmpty();
        }
    }
}
