using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VocabularyBuilder.Application.Categories.Commands.AddCategoryCommand;
using VocabularyBuilder.Application.Categories.Commands.DeleteCategoryCommand;
using VocabularyBuilder.Application.Categories.Commands.UpdateCategoryCommand;
using VocabularyBuilder.Application.Categories.Queries.GetCategories;

namespace VocabularyBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] AddCategoryCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }
        [HttpPut("UpdateCategory")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command)
        {
             await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("DeleteCategory")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand command)
        {
             await _mediator.Send(command);
            return NoContent();
        }
    }
}