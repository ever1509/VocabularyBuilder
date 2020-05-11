using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VocabularyBuilder.Data;

namespace VocabularyBuilder.Application.FlashCards.Commands.DeleteFlashCard
{
    public class DeleteFlashCardCommandHandler:IRequestHandler<DeleteFlashCardCommand>
    {
        private readonly VocabularyBuilderContext _context;

        public DeleteFlashCardCommandHandler(VocabularyBuilderContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteFlashCardCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.FlashCards.FindAsync(request.Id);

            if (entity == null)
                throw new Exception($"{nameof(FlashCards)} not found the entity with the Id {request.Id}");

            _context.FlashCards.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
