using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommandHandler:IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IVocabularyBuilderDbContext _context;

        public UpdateCategoryCommandHandler(IVocabularyBuilderDbContext context)
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
