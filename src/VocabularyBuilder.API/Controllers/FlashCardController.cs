using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VocabularyBuilder.Application.Categories.Queries.GetCategories;
using VocabularyBuilder.Application.Common.Enums;
using VocabularyBuilder.Application.FlashCards.Commands.AddFlashCard;
using VocabularyBuilder.Application.FlashCards.Commands.DeleteFlashCard;
using VocabularyBuilder.Application.FlashCards.Commands.UpdateFlashCard;
using VocabularyBuilder.Application.FlashCards.Queries.GetFlashCards;

namespace VocabularyBuilder.API.Controllers
{
    [Route("api/[controller]")]
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
        [AllowAnonymous]
        public async Task<ActionResult<FlashCardsListVm>> GetFlashCards(TypeCardStatus typeCard)
        {
            var vm = await _mediator.Send(new GetFlashCardsQuery() {TypeCard = typeCard});
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] AddFlashCardCommand command)
        {
            var movieId = await _mediator.Send(command);
            return Ok(movieId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFlashCardCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteFlashCardCommand() {Id = id});

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