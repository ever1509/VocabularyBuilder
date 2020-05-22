using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Models.Requests;
using Application.Common.Models.Responses;
using Application.FlashCards.Commands.AddFlashCardCommand;
using Domain.Enums;
using WebAPI;
using Xunit;

namespace VocabularyBuilder.IntegrationTests.API.Base
{
    public class IntegrationTestBase:IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient TestClient;
        public IntegrationTestBase()
        {
            var factory = new CustomWebApplicationFactory<Startup>();
            TestClient = factory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        protected async Task<int> AddFlashCardAsync()
        {
            var command = GetFlashCardCommand();

            var response = await TestClient.PostAsJsonAsync("api/flashcard/addflashcard", command);

            return await response.Content.ReadAsAsync<int>();
        }
        private async Task<string> GetJwtAsync()
        {
            var response = await TestClient.PostAsJsonAsync("api/identity/register", new UserRegistrationRequest()
            {
                Email = "orelle01@test.com",
                Password = "Orelle01234!",
                Role = null
            });

            var registrationResponse = await response.Content.ReadAsAsync<AuthSuccessResponse>();

            return registrationResponse.Token;
        }
        private AddFlashCardCommand GetFlashCardCommand()
        {
            return new AddFlashCardCommand()
            {
                MainWord = "Shoes",
                Meaning = "something useful to protect your feet",
                Example = "I have a lot shoes",
                Category = 2,
                TypeCard = TypeCardStatus.Daily,
                Picture = new byte[4]
            };
        }
    }
}
