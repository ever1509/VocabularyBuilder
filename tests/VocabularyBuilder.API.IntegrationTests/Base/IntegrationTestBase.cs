using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.Common.Models.Requests;
using Application.Common.Models.Responses;
using Application.FlashCards.Commands.AddFlashCard;
using Domain.Enums;

namespace VocabularyBuilder.API.IntegrationTests.Base
{
    public class IntegrationTestBase :AppTestFixture
    {
        protected readonly HttpClient TestClient;
        protected IntegrationTestBase()
        {
            var fixture = new AppTestFixture();
            TestClient = fixture.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        protected async Task<int> AddFlashCardAsync()
        {
            var command = GetFlashCardCommand();

            var response = await TestClient.PostAsJsonAsync("api/FlashCard/AddFlashCard", command);

            return await response.Content.ReadAsAsync<int>();
        }
        private async Task<string> GetJwtAsync()
        {
            var response = await TestClient.PostAsJsonAsync("api/Identity/Register", new UserRegistrationRequest()
            {
                Email = TestUsersSettings.UserEmail,
                Password = TestUsersSettings.Password,
                Role = null
            });

            var registrationResponse = await response.Content.ReadAsAsync<AuthSuccessResponse>();

            return registrationResponse.Token;
        }
        private AddFlashCardCommand GetFlashCardCommand()
        {
            return new AddFlashCardCommand()
            {
                MainWord = "HeadSets",
                Meaning = "Object used to listening to music with the ears",
                Example = "I have using headset all day",
                Category = 2,
                TypeCard = TypeCardStatus.Daily,
                Picture = new byte[4]
            };
        }
    }
}
