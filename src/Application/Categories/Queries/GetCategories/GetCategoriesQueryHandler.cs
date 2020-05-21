using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler:IRequestHandler<GetCategoriesQuery,CategoriesListVm>
    {
        private readonly IVocabularyBuilderDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IVocabularyBuilderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CategoriesListVm> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CategoriesListVm()
            {
                Categories = categories
            };
        }
    }
}
