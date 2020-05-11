using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using VocabularyBuilder.Application.Common.Enums;

namespace VocabularyBuilder.Application.FlashCards.Queries.GetFlashCards
{
    public class GetFlashCardsQuery:IRequest<FlashCardsListVm>
    {
        public TypeCardStatus TypeCard { get; set; }
    }
}
