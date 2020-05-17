using System;
using System.Collections.Generic;
using System.Text;
using FakeItEasy;
using MediatR;
using Microsoft.Extensions.Logging;
using VocabularyBuilder.API.Controllers;

namespace VocabularyBuilder.UnitTests.API.Base
{
    public class ControllerTestBase<T> where T:class
    {
        private readonly IMediator _mediatorFake;
        private readonly ILogger<T> _loggerFake;
        public ControllerTestBase()
        {
            _mediatorFake = A.Fake<IMediator>();

            ConfigureMediator(_mediatorFake);

            _loggerFake = A.Fake<ILogger<T>>();

        }
        private void ConfigureMediator(IMediator mediatorFake)
        {
            //TODO: Configure different mock for commands

            //A.CallTo(() => mediatorFake.Send(A<AddMovieLikeCommand>._, A<CancellationToken>._))
            //    .Returns(AddMovieLikeFake());
            //A.CallTo(() => mediatorFake.Send(A<CreateMovieCommand>._, A<CancellationToken>._))
            //    .Returns(CreateUpdateMovie());
            //A.CallTo(() => mediatorFake.Send(A<DeleteMovieCommand>._, A<CancellationToken>._));
            //A.CallTo(() => mediatorFake.Send(A<UpdateMovieCommand>._, A<CancellationToken>._));

            //A.CallTo(() => mediatorFake.Send(A<GetAllMoviesListQuery>._, A<CancellationToken>._))
            //    .Returns(GetMoviesListQueryFake());
            //A.CallTo(() => mediatorFake.Send(A<GetMovieDetailQuery>._, A<CancellationToken>._))
            //    .Returns(GetMovieDetailFake());
            //A.CallTo(() => mediatorFake.Send(A<RentalMovieCommand>._, A<CancellationToken>._));
            //A.CallTo(() => mediatorFake.Send(A<ReturnMovieCommand>._, A<CancellationToken>._))
            //    .Returns(ReturnFakeMovie());
        }
    }
}
