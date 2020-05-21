using MediatR;

namespace Application.Categories.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommand:IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
