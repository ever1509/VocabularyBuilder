using System;
using System.Collections.Generic;
using System.Text;

namespace VocabularyBuilder.Domain.Entities
{
    public class FlashCard
    {
        public FlashCard()
        {
        }

        public int FlashCardId { get; set; }
        public string MainWord { get; set; }
        public string Example { get; set; }
        public int CategoryId { get; set; }
        public DateTime? FlashCardDate { get; set; }
        public int TypeCardId { get; set; }
        public byte[] FlashCardPicture { get; set; }
        public int MeaningId { get; set; }

        public virtual Meaning Meaning { get; set; }
        public virtual TypeCard TypeCard { get; set; }
        public virtual Category Category { get; set; }



    }
}
