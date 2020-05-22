using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.FlashCards.Commands.UpdateFlashCardCommand
{
    public class UpdateFlashCardCommandHandler : IRequestHandler<UpdateFlashCardCommand, bool>
    {
        private readonly IVocabularyBuilderDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public UpdateFlashCardCommandHandler(IVocabularyBuilderDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<bool> Handle(UpdateFlashCardCommand request, CancellationToken cancellationToken)
        {

            if (!(await IsFlashCardUserOwnAsync(request)))
            {
                return false;
            }

            var entity = await _context.FlashCards.SingleOrDefaultAsync(f => f.FlashCardId == request.Id, cancellationToken: cancellationToken);

            if (entity == null)
                throw new Exception($"{nameof(FlashCards)} not found with the Id {request.Id}");

            entity.MainWord = request.MainWord;
            entity.Example = request.Example;
            entity.FlashCardPicture = request.Picture;
            entity.TypeCardId = (int)request.TypeCard;
            entity.CategoryId = request.Category;
            entity.Meaning = request.Meaning;

            await _context.SaveChangesAsync(cancellationToken);



            return true;
        }

        private async Task<bool> IsFlashCardUserOwnAsync(UpdateFlashCardCommand request)
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
