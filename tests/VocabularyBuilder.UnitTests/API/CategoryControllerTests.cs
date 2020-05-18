using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VocabularyBuilder.API.Controllers;
using VocabularyBuilder.Application.Categories.Commands.AddCategoryCommand;
using VocabularyBuilder.Application.Categories.Commands.DeleteCategoryCommand;
using VocabularyBuilder.Application.Categories.Commands.UpdateCategoryCommand;
using VocabularyBuilder.Application.Categories.Queries.GetCategories;
using VocabularyBuilder.UnitTests.API.Base;
using Xunit;

namespace VocabularyBuilder.UnitTests.API
{
    public class CategoryControllerTests : ControllerTestBase<CategoryController>
    {
        [Fact]
        public async Task CreateCategoryTest()
        {
            //Arrange
            var controller = new CategoryController(MediatorFake);

            //Act
            var result = await controller.Create(new AddCategoryCommand()
            {
                Description = "Food"
            });

            //Assert
            result.Should().BeOfType<ActionResult<CategoryDto>>();

            var r = (OkObjectResult) result.Result;
            r.Should().NotBeNull();
            r.StatusCode.Should().Be(StatusCodes.Status200OK);
            r.Value.Should().BeEquivalentTo(new CategoryDto() {Id = 1, Description = "Food"});

        }
        [Fact]
        public async Task UpdateCategoryTest()
        {
            //Arrange
            var controller = new CategoryController(MediatorFake);

            //Act
            var result = await controller.Update(new UpdateCategoryCommand
            {
               Id = 1,
                Description = "Food"
            });

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<NoContentResult>();
        }
        [Fact]
        public async Task DeleteCategoryTest()
        {
            //Arrange
            var controller = new CategoryController(MediatorFake);

            //Act
            var result = await controller.Delete(new DeleteCategoryCommand()
            {
                Id = 1
            });

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<NoContentResult>();

        }
    }
}
