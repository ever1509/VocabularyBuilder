using System.Threading.Tasks;
using Application.Common.Models.Requests;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using VocabularyBuilder.UnitTests.API.Base;
using Xunit;

namespace VocabularyBuilder.UnitTests.API
{
    public  class IdentityControllerTests:ControllerTestBase<IdentityController>
    {
        [Fact]
        public async Task RegisterUserTest()
        {
            //Arrange
            var controller = new IdentityController(IdentityServiceFake);
            
            //Act
            var result = await controller.Register(new UserRegistrationRequest()
            {
                Password = "somePass0123!",
                Email = "test01@test.com"
            });


            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();

        }

        [Fact]
        public async Task LoginUserTest()
        {
            //Arrange
            var controller = new IdentityController(IdentityServiceFake);

            //Act
            var result = await controller.Login(new UserLoginRequest()
            {
                Password = "somePass0123!",
                Email = "test01@test.com"
            });

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task RefreshTokenTest()
        {
            //Arrange
            var controller = new IdentityController(IdentityServiceFake);

            //Act
            var result = await controller.Refresh(new RefreshTokenRequest()
            {
                Token = "somePass0123!",
                RefreshToken = "test01@test.com"
            });

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
