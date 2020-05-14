using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using VocabularyBuilder.Application.Categories.Queries.GetCategories;
using VocabularyBuilder.Application.Common.Enums;
using VocabularyBuilder.Application.FlashCards.Commands.AddFlashCard;
using VocabularyBuilder.Application.FlashCards.Commands.DeleteFlashCard;
using VocabularyBuilder.Application.FlashCards.Commands.UpdateFlashCard;
using VocabularyBuilder.Application.FlashCards.Queries.GetFlashCards;
using VocabularyBuilder.Infrastructure.Identity.Extensions;

namespace VocabularyBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [EnableCors("AllowVocabularyBuilderApp")]
    public class FlashCardController : ControllerBase
    {
        private readonly ILogger<FlashCardController> _logger;
        private readonly IMediator _mediator;

        public FlashCardController(ILogger<FlashCardController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("GetFlashCards/{typeCard:int}")]
        public async Task<ActionResult<FlashCardsListVm>> GetFlashCards(TypeCardStatus typeCard)
        {
            var vm = await _mediator.Send(new GetFlashCardsQuery() {TypeCard = typeCard,UserId=HttpContext.GetUserId()});
            return Ok(vm);
        }

        [HttpPost("AddFlashCard")]
        public async Task<ActionResult<int>> Create([FromBody] AddFlashCardCommand command)
        {
            command.UserId = HttpContext.GetUserId();
            var flashCardId = await _mediator.Send(command);
            return Ok(flashCardId);
        }

        [HttpPut("UpdateFlashCard")]
        public async Task<IActionResult> Update([FromBody] UpdateFlashCardCommand command)
        {
            command.UserId = HttpContext.GetUserId();
            var result =await _mediator.Send(command);

            if (!result)
                return BadRequest(new { error = "You do not own this FlashCard" });

            return NoContent();

        }

        [HttpDelete("DeleteFlashCard/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {            
            var result =await _mediator.Send(new DeleteFlashCardCommand() {Id = id, UserId= HttpContext.GetUserId()});

            if(!result)
                return BadRequest(new { error = "You do not own this FlashCard" });

            return NoContent();
        }

        [HttpGet("GetCategories")]
        public async Task<ActionResult<CategoriesListVm>> GetCategories()
        {
            var vm = await _mediator.Send(new GetCategoriesQuery());

            return Ok(vm);
        }

    }
}