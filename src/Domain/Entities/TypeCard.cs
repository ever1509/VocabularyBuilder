using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TypeCard
    {
        public TypeCard()
        {
            FlashCards = new HashSet<FlashCard>();
        }
        public int TypeCardId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FlashCard> FlashCards { get; set; }
    }
}
