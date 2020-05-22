using MediatR;

namespace Application.FlashCards.Commands.DeleteFlashCardCommand
{
    public class DeleteFlashCardCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
