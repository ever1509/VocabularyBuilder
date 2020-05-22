using System.Threading.Tasks;
using Application.Categories.Commands.AddCategoryCommand;
using Application.Categories.Commands.DeleteCategoryCommand;
using Application.Categories.Commands.UpdateCategoryCommand;
using Application.Categories.Queries.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/categories/")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("addcategory")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] AddCategoryCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }
        [HttpPut("updatecategory")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("deletecategory")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}