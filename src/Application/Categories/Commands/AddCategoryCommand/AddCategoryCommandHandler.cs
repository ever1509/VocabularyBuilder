using System.Threading;
using System.Threading.Tasks;
using Application.Categories.Queries.GetCategories;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Categories.Commands.AddCategoryCommand
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, CategoryDto>
    {
        private readonly IVocabularyBuilderDbContext _context;
        private readonly IMapper _mapper;

        public AddCategoryCommandHandler(IVocabularyBuilderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Category()
            {
                Description = request.Description
            };

            _context.Categories.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryDto>(entity);
        }
    }
}
