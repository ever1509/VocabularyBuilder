using System.Linq;
using System.Threading.Tasks;
using Application.Categories.Queries.GetCategories;
using Application.FlashCards.Commands.AddFlashCardCommand;
using Application.FlashCards.Commands.UpdateFlashCardCommand;
using Application.FlashCards.Queries.GetFlashCards;
using Domain.Enums;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using VocabularyBuilder.UnitTests.API.Base;
using Xunit;

namespace VocabularyBuilder.UnitTests.API
{
    public class FlashControllerTests:ControllerTestBase<FlashCardController>
    {
        [Fact]
        public async Task GetCategoriesTest()
        {
            //Arrange
            var controller = new FlashCardController(LoggerFake,MediatorFake);

            //Act
            var result = await controller.GetCategories();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<CategoriesListVm>>();

            var r = (OkObjectResult) result.Result;

            r.StatusCode.Should().Be(StatusCodes.Status200OK);
            r.Value.Should().BeEquivalentTo(await GetCategoriesQueryFake());
        }

        [Theory]
        [InlineData(TypeCardStatus.Weekly)]
        [InlineData(TypeCardStatus.Daily)]
        [InlineData(TypeCardStatus.Monthly)]
        public async Task GetFlashCardsTest(TypeCardStatus typeCard)
        {
            //Arrange
            var controller= new FlashCardController(LoggerFake,MediatorFake);

            //Act
            var result = await controller.GetFlashCards(typeCard);
            
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<FlashCardsListVm>>();

            var r = (OkObjectResult) result.Result;

            r.StatusCode.Should().Be(StatusCodes.Status200OK);
            r.Value.Should().BeEquivalentTo(await GeFlashCardsFake());
        }

        [Fact]
        public async Task CreateFlashCardTest()
        {
            //Arrange
            var controller = new FlashCardController(LoggerFake,MediatorFake);
            var flashCard = (await GeFlashCardsFake()).FlashCards.FirstOrDefault();

            //Act
            var result = await controller.Create(new AddFlashCardCommand()
            {
                Meaning = flashCard.Meaning,
                Category = flashCard.CategoryId,
                Example = flashCard.Example,
                MainWord = flashCard.MainWord,
                TypeCard = flashCard.TypeCard,
                Picture = flashCard.Picture
            });

            //Assert
            result.Should().BeOfType<ActionResult<int>>();

            var r = (OkObjectResult)result.Result;
            r.Should().NotBeNull();
            r.StatusCode.Should().Be(StatusCodes.Status200OK);
            r.Value.Should().BeEquivalentTo(flashCard.Id);
        }
        [Fact]
        public async Task UpdateFlashCardTest()
        {
            //Arrange
            var controller = new FlashCardController(LoggerFake,MediatorFake);
            var flashCard = (await GeFlashCardsFake()).FlashCards.FirstOrDefault();

            //Act
            var result = await controller.Update(new UpdateFlashCardCommand()
                {
                    Id = flashCard.Id,
                    Meaning =flashCard.Meaning,
                    Category = flashCard.CategoryId,
                    TypeCard = flashCard.TypeCard,
                    Example = flashCard.Example,
                    MainWord = flashCard.MainWord,
                    Picture = flashCard.Picture
                }
            );

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task DeleteFlashCardTest()
        {
            //Arrange
            var controller = new FlashCardController(LoggerFake,MediatorFake);

            //Act
            var result = await controller.Delete(1);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<NoContentResult>();
        }
    }
}
