using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VocabularyBuilder.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery:IRequest<CategoriesListVm>
    {
    }
}
