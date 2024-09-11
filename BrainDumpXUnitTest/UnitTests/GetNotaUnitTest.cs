using BrainDumpApi_2.Controllers;
using BrainDumpApi_2.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainDumpXUnitTest.UnitTests
{
    public class GetNotaUnitTest : IClassFixture<NotasUnitTestController>
    {
        private readonly NotasController _controller;

        public GetNotaUnitTest(NotasUnitTestController controller)
        {
            _controller = new NotasController(controller._repository, controller._mapper);
        }

        [Fact]
        public async Task GetNotaById_Return_OkResult()
        {
            // Arrange
            var prodId = 2;

            // Act
            var data = await _controller.Get(prodId);

            // Assert (xUnit)
            //var okResult = Assert.IsType<OkObjectResult>(data.Result);
            //Assert.Equal(200, okResult.StatusCode);

            // Assert (fluentAssertions)
            data.Result.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);
        }
    }
}
