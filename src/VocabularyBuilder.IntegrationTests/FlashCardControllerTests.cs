using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using VocabularyBuilder.Application.Categories.Queries.GetCategories;
using VocabularyBuilder.Application.Common.Enums;
using VocabularyBuilder.Application.FlashCards.Commands.AddFlashCard;
using VocabularyBuilder.Application.FlashCards.Queries.GetFlashCards;
using VocabularyBuilder.Domain.Entities;
using Xunit;

namespace VocabularyBuilder.IntegrationTests
{
    public class FlashCardControllerTests: IntegrationTest
    {
        [Fact]
        public async Task GetCategories_Test()
        {
            //Arrange
            await AuthenticateAsync();

            //Act
            var response = await TestClient.GetAsync("api/FlashCard/GetCategories");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<CategoriesListVm>()).Categories.Should().HaveCountLessOrEqualTo(0);

        }

        [Fact]
        public async Task GetFlashCards_WhenAddedFlashCardInTheDatabase()
        {
         //Arrange
         await AuthenticateAsync();
        var flashCardId= await AddFlashCardAsync();
         //Act
         var response = await TestClient.GetAsync("api/FlashCard/GetFlashCards/1");

         //Assert
         response.StatusCode.Should().Be(HttpStatusCode.OK);
         var flashCardReturned = (await response.Content.ReadAsAsync<FlashCardsListVm>()).FlashCards.FirstOrDefault();
         flashCardReturned.Id.Should().Be(flashCardId);
         flashCardReturned.MainWord.Should().Be("HeadSets");

        }
    }
}
