using Domain.Enums;
using MediatR;

namespace Application.FlashCards.Queries.GetFlashCards
{
    public class GetFlashCardsQuery:IRequest<FlashCardsListVm>
    {
        public TypeCardStatus TypeCard { get; set; }
        public string UserId { get; set; }
    }
}
