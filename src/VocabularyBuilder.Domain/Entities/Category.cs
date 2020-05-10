using System;
using System.Collections.Generic;
using System.Text;

namespace VocabularyBuilder.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            FlashCards= new HashSet<FlashCard>();
        }
        public int CategoryId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FlashCard> FlashCards { get; set; }
    }
}
