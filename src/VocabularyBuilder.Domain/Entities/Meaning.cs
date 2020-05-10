using System;
using System.Collections.Generic;
using System.Text;

namespace VocabularyBuilder.Domain.Entities
{
    public class Meaning
    {
        public int MeaningId { get; set; }
        public string Description { get; set; }

        public virtual FlashCard FlashCard { get; set; }
    }
}
