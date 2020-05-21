using MediatR;

namespace Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery:IRequest<CategoriesListVm>
    {
    }
}
