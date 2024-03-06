using ProjectExam.Models;
using ProjectExam.Repositories.Contracts;
using ProjectExam.Services.Contracts;

namespace ProjectExam.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

  

    }

    
}