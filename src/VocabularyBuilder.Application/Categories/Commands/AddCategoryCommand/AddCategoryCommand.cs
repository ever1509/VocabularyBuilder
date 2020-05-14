using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using VocabularyBuilder.Application.Categories.Queries.GetCategories;

namespace VocabularyBuilder.Application.Categories.Commands.AddCategoryCommand
{
    public class AddCategoryCommand:IRequest<CategoryDto>
    {
        public string Description { get; set; }
    }
}
