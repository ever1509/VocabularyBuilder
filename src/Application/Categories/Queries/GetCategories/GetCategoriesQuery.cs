using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery:IRequest<CategoriesListVm>
    {
    }
}
