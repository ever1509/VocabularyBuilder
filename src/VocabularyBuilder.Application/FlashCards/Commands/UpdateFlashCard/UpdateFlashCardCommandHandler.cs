using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VocabularyBuilder.Data;

namespace VocabularyBuilder.Application.FlashCards.Commands.UpdateFlashCard
{
    public class UpdateFlashCardCommandHandler :IRequestHandler<UpdateFlashCardCommand>
    {
        private readonly VocabularyBuilderContext _context;
        public UpdateFlashCardCommandHandler(VocabularyBuilderContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateFlashCardCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.FlashCards.SingleOrDefaultAsync(f => f.FlashCardId == request.Id, cancellationToken: cancellationToken);

            if (entity == null)
                throw new Exception($"{nameof(FlashCards)} not found with the Id {request.Id}");

            entity.MainWord = request.MainWord;
            entity.Example = request.Example;
            entity.FlashCardPicture = request.Picture;
            entity.TypeCardId = (int)request.TypeCard;
            entity.CategoryId = request.Category;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
