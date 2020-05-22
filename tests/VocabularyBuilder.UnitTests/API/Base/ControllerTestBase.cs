using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Categories.Commands.AddCategoryCommand;
using Application.Categories.Commands.DeleteCategoryCommand;
using Application.Categories.Commands.UpdateCategoryCommand;
using Application.Categories.Queries.GetCategories;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.FlashCards.Commands.AddFlashCardCommand;
using Application.FlashCards.Commands.DeleteFlashCardCommand;
using Application.FlashCards.Commands.UpdateFlashCardCommand;
using Application.FlashCards.Queries.GetFlashCards;
using Domain.Entities;
using Domain.Enums;
using FakeItEasy;
using MediatR;
using Microsoft.Extensions.Logging;

namespace VocabularyBuilder.UnitTests.API.Base
{
    public class ControllerTestBase<T> where T:class
    {
        public readonly IMediator MediatorFake;
        public readonly ILogger<T> LoggerFake;
        public readonly IIdentityService IdentityServiceFake;
        public ControllerTestBase()
        {
            MediatorFake = A.Fake<IMediator>();

            ConfigureMediator(MediatorFake);

            LoggerFake = A.Fake<ILogger<T>>();

            IdentityServiceFake = A.Fake<IIdentityService>();

            ConfigureIdentityServiceFake(IdentityServiceFake);

        }

        private void ConfigureIdentityServiceFake(IIdentityService identityServiceFake)
        {
            A.CallTo(() => identityServiceFake.LoginAsync(A<string>._, A<string>._)).Returns(GenerateAuthenticationResult());

            A.CallTo(() => identityServiceFake.RegisterAsync(A<string>._, A<string>._, null))
                .Returns(GenerateAuthenticationResult());

            A.CallTo(() => identityServiceFake.RefreshTokenAsync(A<string>._, A<string>._))
                .Returns(GenerateAuthenticationResult());

        }

        public Task<AuthenticationResult> GenerateAuthenticationResult()
        {
            return Task.Run(() =>
            {
                return new AuthenticationResult()
                {
                    Token = "0fe563fe-94e1-4e38-bd84-0d527b0e9e32",
                    Errors = null,
                    RefreshToken = "0fe563fe-94e1-4e38-bd84-0d527b0e9e32",
                    Success = true
                };
            });
        }

        private void ConfigureMediator(IMediator mediatorFake)
        {
            A.CallTo(() => mediatorFake.Send(A<AddFlashCardCommand>._, A<CancellationToken>._))
                .Returns(AddFlashCardCommandFake());
            A.CallTo(() => mediatorFake.Send(A<UpdateFlashCardCommand>._, A<CancellationToken>._))
                .Returns(true);
            A.CallTo(() => mediatorFake.Send(A<DeleteFlashCardCommand>._, A<CancellationToken>._))
                .Returns(true);
            A.CallTo(() => mediatorFake.Send(A<AddCategoryCommand>._, A<CancellationToken>._))
                .Returns(AddCategoryCommandFake());

            A.CallTo(() => mediatorFake.Send(A<UpdateCategoryCommand>._, A<CancellationToken>._)).Returns(Unit.Value);
            A.CallTo(() => mediatorFake.Send(A<DeleteCategoryCommand>._, A<CancellationToken>._)).Returns(Unit.Value);

            A.CallTo(() => mediatorFake.Send(A<GetFlashCardsQuery>._, A<CancellationToken>._))
                .Returns(GeFlashCardsFake());
            A.CallTo(() => mediatorFake.Send(A<GetCategoriesQuery>._, A<CancellationToken>._))
                .Returns(GetCategoriesQueryFake());
        }

        public Task<CategoriesListVm> GetCategoriesQueryFake()
        {
            return Task.Run(() => new CategoriesListVm()
            {
                Categories = new List<CategoryDto>()
                {
                    new CategoryDto(){Id=1,Description = "Food"},
                    new CategoryDto(){Id = 2,Description = "Animals"}
                }
            });
        }

        public Task<FlashCardsListVm> GeFlashCardsFake()
        {
            return Task.Run(() =>
            {
                return new FlashCardsListVm()
                {
                    FlashCards = new List<FlashCardDto>()
                    {
                        new FlashCardDto()
                        {
                            MainWord = "HeadSets",
                            Id = 1,
                            CategoryId = 1,
                            TypeCard = TypeCardStatus.Weekly,
                            Meaning = "Device use with ears",
                            Example = "This headsets are amazing",
                            Picture = new byte[]{1,2,3,4}
                        },
                        new FlashCardDto()
                        {
                            MainWord = "Computer",
                            Id = 2,
                            CategoryId = 1,
                            TypeCard = TypeCardStatus.Weekly,
                            Meaning = "Device use at work",
                            Example = "The computer is better than mine",
                            Picture = new byte[]{5,6,7,8}
                        }
                        ,
                        new FlashCardDto()
                        {
                            MainWord = "Cellphone",
                            Id = 3,
                            CategoryId = 1,
                            TypeCard = TypeCardStatus.Weekly,
                            Meaning = "Device use to talk with someone",
                            Example = "your celphone is big"
                        }
                    }
                };
            });
        }

        private Task<CategoryDto> AddCategoryCommandFake()
        {
            return Task.Run(() => new CategoryDto()
            {
                Description = "Food",
                Id = 1
            });
        }

        private Task<int> AddFlashCardCommandFake()
        {
            return Task.Run(() =>
            {
                var fc= new FlashCard()
                {
                    MainWord = "HeadSets",
                    TypeCardId = 1,
                    CategoryId = 1,
                    FlashCardId = 1,
                    Example = "Device headset test",
                    FlashCardPicture = new byte[] {2, 4, 2, 4},
                    FlashCardDate = DateTime.UtcNow,
                    Meaning = "Device use in the ears"

                };
                return fc.FlashCardId;
            });
        }
    }
}
