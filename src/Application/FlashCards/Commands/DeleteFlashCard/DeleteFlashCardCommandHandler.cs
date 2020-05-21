using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.FlashCards.Commands.DeleteFlashCard
{
    public class DeleteFlashCardCommandHandler:IRequestHandler<DeleteFlashCardCommand,bool>
    {
        private readonly IVocabularyBuilderDbContext _context;

        public DeleteFlashCardCommandHandler(IVocabularyBuilderDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteFlashCardCommand request, CancellationToken cancellationToken)
        {
            if (!(await IsFlashCardUserOwnAsync(request)))
            {
                return false;
            }

            var entity = await _context.FlashCards.FindAsync(request.Id);

            if (entity == null)
                throw new Exception($"{nameof(FlashCards)} not found the entity with the Id {request.Id}");

            _context.FlashCards.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        private async Task<bool> IsFlashCardUserOwnAsync(DeleteFlashCardCommand request)
        {
            var fc = await _context.FlashCards.AsNoTracking().SingleOrDefaultAsync(f => f.FlashCardId == request.Id);
            if (fc == null)
            {
                return false;
            }

            if (fc.UserId != request.UserId)
            {
                return false;
            }

            return true;
        }
    }
}
