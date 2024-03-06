using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Moq;
using ProjectExam.AzureFunctions.AzureFunctions.Event;
using ProjectExam.Services.Contracts;
using Xunit;

namespace ProjectExam.UnitTests
{
    public class TestDeleteEvent
    {
        [Fact]
        public async Task DeleteEvent_ReturnsOkResult()
        {
            // Arrange
            var eventServiceMock = new Mock<IEventService>();
            var loggerMock = new Mock<ILogger>();

            var deleteEventFunction = new DeleteEvent(eventServiceMock.Object);

            var reqMock = new Mock<HttpRequestData>();
            reqMock.SetupGet(r => r.Method).Returns("DELETE");

            var eventId = Guid.NewGuid(); 

            // Act
            var result = await deleteEventFunction.Run(reqMock.Object, loggerMock.Object, eventId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }


    }
}