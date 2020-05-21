using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using VocabularyBuilder.Data;

namespace VocabularyBuilder.Application.Categories.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommand>
    {
        private readonly VocabularyBuilderContext _context;
        public DeleteCategoryCommandHandler(VocabularyBuilderContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.FindAsync(request.Id);

            if (entity == null)
                throw new Exception($"{typeof(Category)} not found with the Id {request.Id}");

            _context.Categories.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
