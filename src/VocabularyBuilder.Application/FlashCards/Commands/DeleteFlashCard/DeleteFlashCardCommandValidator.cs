using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace VocabularyBuilder.Application.FlashCards.Commands.DeleteFlashCard
{
    public class DeleteFlashCardCommandValidator:AbstractValidator<DeleteFlashCardCommand>
    {
        public DeleteFlashCardCommandValidator()
        {
            RuleFor(f => f.Id).NotEmpty();
        }
    }
}
