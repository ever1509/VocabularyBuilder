using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using VocabularyBuilder.Application.Common.Enums;
using VocabularyBuilder.Application.FlashCards.Commands.AddFlashCard;
using VocabularyBuilder.Data;
using VocabularyBuilder.Infrastructure.Identity;
using Xunit;

namespace VocabularyBuilder.IntegrationTests
{
    public class IntegrationTest :IClassFixture<AppTestFixture>
    {
        protected readonly HttpClient TestClient;
        protected IntegrationTest()
        {
            var fixture = new AppTestFixture();
            TestClient = fixture.CreateClient();
        }

        protected async Task AuthenticateAsync(bool refreshToken=false)
        {
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync(refreshToken));
        }

        protected async Task<int> AddFlashCardAsync()
        {
            var command= new AddFlashCardCommand()
            {
                MainWord = "HeadSets",
                Meaning = "Object used to listening to music with the ears",
                Example = "I have using headset all day",
                Category = 2,
                TypeCard = TypeCardStatus.Daily,
                Picture = new byte[4]
            };

            var response= await TestClient.PostAsJsonAsync("api/FlashCard/AddFlashCard",command);

           return await response.Content.ReadAsAsync<int>();
        }

        private async Task<string> GetJwtAsync(bool refreshToken)
        {
            var response = await TestClient.PostAsJsonAsync("api/Identity/Register", new UserRegistrationRequest()
            {
                Email = "test@integration.com",
                Password = "SomePass1234!"
            });

            var registrationResponse = await response.Content.ReadAsAsync<AuthSuccessResponse>();

            return registrationResponse.Token;
        }
    }
}
