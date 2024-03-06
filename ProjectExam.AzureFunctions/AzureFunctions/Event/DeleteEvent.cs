using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ProjectExam.Services.Contracts;


namespace ProjectExam.AzureFunctions.AzureFunctions.Event
{
    public class DeleteEvent
    {
        private readonly IEventService _eventService;

        public DeleteEvent(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Function("DeleteEvent")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "events/{eventId}/delete")] HttpRequestData req,
            ILogger log, Guid eventId)
        {
            log.LogInformation($"Deleting event with id: {eventId}");

            try
            {
                await _eventService.Delete(eventId);

                return new OkObjectResult("Event deleted successfully.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error deleting event.");
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
