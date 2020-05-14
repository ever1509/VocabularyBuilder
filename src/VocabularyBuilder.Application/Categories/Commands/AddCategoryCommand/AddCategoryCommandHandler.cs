using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VocabularyBuilder.Application.Categories.Queries.GetCategories;
using VocabularyBuilder.Data;

namespace VocabularyBuilder.Application.Categories.Commands.AddCategoryCommand
{
    public class AddCategoryCommandHandler:IRequestHandler<AddCategoryCommand,CategoryDto>
    {
        private readonly VocabularyBuilderContext _context;
        private readonly IMapper _mapper;

        public AddCategoryCommandHandler(VocabularyBuilderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CategoryDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
