using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;
using MediatR;

namespace Application.FlashCards.Commands.UpdateFlashCardCommand
{
    public class UpdateFlashCardCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string MainWord { get; set; }
        public string Example { get; set; }
        public int Category { get; set; }
        public TypeCardStatus TypeCard { get; set; }
        public string Meaning { get; set; }
        public byte[] Picture { get; set; }
    }
}
