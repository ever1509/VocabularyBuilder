using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.FlashCards.Commands.DeleteFlashCardCommand
{
    public class DeleteFlashCardCommandHandler : IRequestHandler<DeleteFlashCardCommand, bool>
    {
        private readonly IVocabularyBuilderDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteFlashCardCommandHandler(IVocabularyBuilderDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
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

            if (fc.UserId != _currentUserService.UserId)
            {
                return false;
            }

            return true;
        }
    }
}
