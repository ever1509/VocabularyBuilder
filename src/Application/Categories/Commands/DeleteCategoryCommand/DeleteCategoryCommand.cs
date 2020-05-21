using MediatR;

namespace Application.Categories.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommand:IRequest
    {
        public int Id { get; set; }
    }
}
