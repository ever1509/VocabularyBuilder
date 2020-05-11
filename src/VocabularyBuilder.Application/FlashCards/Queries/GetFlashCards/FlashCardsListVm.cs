using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VocabularyBuilder.Application.FlashCards.Queries.GetFlashCards
{
    public class FlashCardsListVm
    {
        public List<FlashCardDto> FlashCards { get; set; }
    }
}
