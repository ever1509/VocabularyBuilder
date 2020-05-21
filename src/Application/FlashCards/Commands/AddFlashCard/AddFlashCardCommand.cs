using Domain.Enums;
using MediatR;

namespace Application.FlashCards.Commands.AddFlashCard
{
    public class AddFlashCardCommand : IRequest<int>
    {
        public string MainWord { get; set; }
        public string Example { get; set; }
        public int Category { get; set; }
        public TypeCardStatus TypeCard { get; set; }
        public string Meaning { get; set; }
        public byte[] Picture { get; set; }

        public string UserId { get; set; }
    }
}
