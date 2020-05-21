using MediatR;

namespace Application.FlashCards.Commands.DeleteFlashCard
{
    public class  DeleteFlashCardCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
    }
}
