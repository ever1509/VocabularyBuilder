using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VocabularyBuilder.Application.Common.Enums;

namespace VocabularyBuilder.Application.FlashCards.Queries.GetFlashCards
{
    public class FlashCardDto
    {
        public int Id { get; set; }
        public string MainWord { get; set; }
        public string Example { get; set; }
        public int CategoryId { get; set; }
        public int MeaningId { get; set; }
        public string Meaning { get; set; }
        public TypeCardStatus TypeCard { get; set; }


    }
}
