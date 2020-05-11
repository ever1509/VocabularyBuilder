using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace VocabularyBuilder.Application.FlashCards.Queries.GetFlashCards
{
    public class GetFlashCardsQueryValidator:AbstractValidator<GetFlashCardsQuery>
    {
        public GetFlashCardsQueryValidator()
        {
            RuleFor(f => f.TypeCard).NotEmpty();
        }
    }
}
