using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VocabularyBuilder.Data;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.Application.Categories.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommandHandler:IRequestHandler<UpdateCategoryCommand>
    {
        private readonly VocabularyBuilderContext _context;

        public UpdateCategoryCommandHandler(VocabularyBuilderContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.SingleOrDefaultAsync(c=>c.CategoryId==request.Id);

            if(entity==null)
                throw new Exception($"{typeof(Category)} entity does'nt exist with the id {request.Id}");

            entity.Description = request.Description;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
