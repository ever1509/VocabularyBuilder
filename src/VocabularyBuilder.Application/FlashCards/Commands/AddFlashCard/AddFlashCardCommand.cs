﻿using MediatR;
using VocabularyBuilder.Application.Common;
using VocabularyBuilder.Application.Common.Enums;

namespace VocabularyBuilder.Application.FlashCards.Commands.AddFlashCard
{
    public class AddFlashCardCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string MainWord { get; set; }
        public string Example { get; set; }
        public int Category { get; set; }
        public TypeCardStatus TypeCard { get; set; }
        public string Meaning { get; set; }
        public byte[] Picture { get; set; }

        public string UserId { get; set; }
    }
}