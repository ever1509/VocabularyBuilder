using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VocabularyBuilder.Data;

namespace VocabularyBuilder.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler:IRequestHandler<GetCategoriesQuery,CategoriesListVm>
    {
        private readonly VocabularyBuilderContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(VocabularyBuilderContext context, IMapper mapper)
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
