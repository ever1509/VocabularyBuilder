using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace VocabularyBuilder.Application.FlashCards.Commands.AddFlashCard
{
    public class AddFlashCardCommandValidator:AbstractValidator<AddFlashCardCommand>
    {
        public AddFlashCardCommandValidator()
        {
            RuleFor(f => f.MainWord).NotEmpty();
            RuleFor(f => f.MainWord).MaximumLength(50);
            RuleFor(f => f.Example).MaximumLength(1000);
            RuleFor(f => f.Category).NotEmpty();
            RuleFor(f => f.TypeCard).NotEmpty();

        }
    }
}
