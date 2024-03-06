using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectExam.Services.Contracts;

namespace ProjectExam.AzureFunctions.AzureFunctions.Event
{
    public class AddEvent
    {
        private readonly IEventService _eventService;

        public AddEvent(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Function("AddEvent")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "event/add")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Adding a new event.");

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var eventData = JsonConvert.DeserializeObject<Models.Event>(requestBody);

                // Ajouter l'événement en appelant le service approprié
                await _eventService.Add(eventData);

                return new OkObjectResult("Event added successfully.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error adding event.");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}





