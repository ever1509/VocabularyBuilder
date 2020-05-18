using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using VocabularyBuilder.API.Controllers;
using VocabularyBuilder.Application.Categories.Commands.AddCategoryCommand;
using VocabularyBuilder.Application.Categories.Commands.DeleteCategoryCommand;
using VocabularyBuilder.Application.Categories.Commands.UpdateCategoryCommand;
using VocabularyBuilder.Application.Categories.Queries.GetCategories;
using VocabularyBuilder.Application.Common.Enums;
using VocabularyBuilder.Application.FlashCards.Commands.AddFlashCard;
using VocabularyBuilder.Application.FlashCards.Commands.DeleteFlashCard;
using VocabularyBuilder.Application.FlashCards.Commands.UpdateFlashCard;
using VocabularyBuilder.Application.FlashCards.Queries.GetFlashCards;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.UnitTests.API.Base
{
    public class ControllerTestBase<T> where T:class
    {
        public readonly IMediator MediatorFake;
        public readonly ILogger<T> LoggerFake;
        public ControllerTestBase()
        {
            MediatorFake = A.Fake<IMediator>();

            ConfigureMediator(MediatorFake);

            LoggerFake = A.Fake<ILogger<T>>();

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

        private Task<CategoriesListVm> GetCategoriesQueryFake()
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

        private Task<FlashCardsListVm> GeFlashCardsFake()
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
                            Example = "This headsets are amazing"
                        },
                        new FlashCardDto()
                        {
                            MainWord = "Computer",
                            Id = 2,
                            CategoryId = 1,
                            TypeCard = TypeCardStatus.Weekly,
                            Meaning = "Device use at work",
                            Example = "The computer is better than mine"
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
