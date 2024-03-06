using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ProjectExam.Services.Contracts;


namespace ProjectExam.AzureFunctions.AzureFunctions.Event
{
    public class GetEvents
    {
        private readonly IEventService _eventService;

        public GetEvents(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Function("GetEvents")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "events")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Getting all events.");

            try
            {
                var events = await _eventService.GetAll();

                return new OkObjectResult(events);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error getting events.");
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
