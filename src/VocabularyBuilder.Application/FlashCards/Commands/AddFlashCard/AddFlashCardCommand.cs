using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using VocabularyBuilder.Application.Common;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.Application.FlashCards.Commands.AddFlashCard
{
    public class AddFlashCardCommand : IRequest
    {
        public string MainWord { get; set; }
        public string Example { get; set; }
        public int Category { get; set; }
        public TypeCardStatus TypeCard { get; set; }
        public string Meaning { get; set; }
        public byte[] Picture { get; set; }
    }
}
