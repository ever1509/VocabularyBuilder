using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Categories.Queries.GetCategories;
using Application.FlashCards.Commands.AddFlashCardCommand;
using Application.FlashCards.Commands.DeleteFlashCardCommand;
using Application.FlashCards.Commands.UpdateFlashCardCommand;
using Application.FlashCards.Queries.GetFlashCards;
using Domain.Enums;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Route("api/flashcard/")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class FlashCardController : ControllerBase
    {
        private readonly ILogger<FlashCardController> _logger;
        private readonly IMediator _mediator;

        public FlashCardController(ILogger<FlashCardController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        /// <summary>
        /// Returns FlashCards according to the type card value
        /// </summary>
        /// <param name="typeCard">This parameter could be 1(Daily), 2(Weekly) or 3(Monthly)</param>
        /// <response code="200">The values of the flashcards was returned in a good way</response>
        /// <returns></returns>
        [HttpGet("getflashcards/{typeCard:int}")]
        public async Task<ActionResult<FlashCardsListVm>> GetFlashCards(TypeCardStatus typeCard)
        {
            var vm = await _mediator.Send(new GetFlashCardsQuery() { TypeCard = typeCard, UserId = HttpContext.GetUserId() });
            return Ok(vm);
        }

        [HttpPost("addflashcard")]
        public async Task<ActionResult<int>> Create([FromBody] AddFlashCardCommand command)
        {
            var flashCardId = await _mediator.Send(command);
            return Ok(flashCardId);
        }

        [HttpPut("updateflashcard")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateFlashCardCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest(new { error = "You do not own this FlashCard" });

            return NoContent();

        }

        [HttpDelete("deleteflashcard/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteFlashCardCommand() { Id = id });

            if (!result)
                return BadRequest(new { error = "You do not own this FlashCard" });

            return NoContent();
        }

        [HttpGet("getcategories")]
        public async Task<ActionResult<CategoriesListVm>> GetCategories()
        {
            var vm = await _mediator.Send(new GetCategoriesQuery());

            return Ok(vm);
        }
    }
}