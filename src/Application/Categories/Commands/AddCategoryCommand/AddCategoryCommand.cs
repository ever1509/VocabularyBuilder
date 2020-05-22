using Application.Categories.Queries.GetCategories;
using MediatR;

namespace Application.Categories.Commands.AddCategoryCommand
{
    public class AddCategoryCommand : IRequest<CategoryDto>
    {
        public string Description { get; set; }
    }
}
