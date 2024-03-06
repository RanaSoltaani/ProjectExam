using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectExam.Services.Contracts;


namespace ProjectExam.AzureFunctions.AzureFunctions.Event
{
    public class UpdateEvent
    {
        private readonly IEventService _eventService;

        public UpdateEvent(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Function("UpdateEvent")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "events/{id}")] HttpRequest req,
            ILogger log, string id)
        {
            log.LogInformation($"Updating event with id: {id}");

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var eventData = JsonConvert.DeserializeObject<Models.Event>(requestBody);

                await _eventService.Update(eventData);

                return new OkObjectResult("Event updated successfully.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error updating event.");
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
