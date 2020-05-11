using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VocabularyBuilder.Application.FlashCards.Commands.DeleteFlashCard
{
    public class  DeleteFlashCardCommand:IRequest
    {
        public int Id { get; set; }
    }
}
