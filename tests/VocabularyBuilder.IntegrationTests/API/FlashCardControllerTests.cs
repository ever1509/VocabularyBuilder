using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Application.Categories.Queries.GetCategories;
using Application.FlashCards.Queries.GetFlashCards;
using FluentAssertions;
using Newtonsoft.Json;
using VocabularyBuilder.IntegrationTests.API.Base;
using Xunit;

namespace VocabularyBuilder.IntegrationTests.API
{
    public class FlashCardControllerTests:IntegrationTestBase
    {
        [Fact]
        public async Task GetCategories_Test()
        {
            //Arrange
            
            await AuthenticateAsync();

            //Act
            var response = await TestClient.GetAsync("api/flashcard/getcategories");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (JsonConvert.DeserializeObject<CategoriesListVm>(await response.Content.ReadAsStringAsync())).Categories.Should().HaveCountLessOrEqualTo(4);

        }

        [Fact]
        public async Task GetFlashCards_Test()
        {
            //Arrange

            await AuthenticateAsync();

            //Act
            var response = await TestClient.GetAsync("api/flashcard/getflashcards/1");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (JsonConvert.DeserializeObject<FlashCardsListVm>(await response.Content.ReadAsStringAsync())).FlashCards.Should().HaveCountLessOrEqualTo(3);

        }

        [Fact]
        public async Task GetFlashCards_WhenAddedFlashCardInTheDatabase()
        {
            //Arrange
            await AuthenticateAsync();
            var flashCardId = await AddFlashCardAsync();
            //Act
            var response = await TestClient.GetAsync("api/flashcard/getflashcards/1");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var flashCardReturned = (JsonConvert.DeserializeObject<FlashCardsListVm>(await response.Content.ReadAsStringAsync())).FlashCards.Last();
            flashCardReturned.Id.Should().Be(flashCardId);
            flashCardReturned.MainWord.Should().Be("Shoes");

        }

    }
}
