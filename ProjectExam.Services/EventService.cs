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

        public async Task Add(Event newevent)
        {
            await _eventRepository.Add(newevent);   
        }

        public async Task Delete(Guid eventId)
        {
            await _eventRepository.Delete(eventId);
        }

        public async Task<Event> Get(Guid eventId)
        {
            return await _eventRepository.Get(eventId);
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _eventRepository.GetAll();
        }

        public async Task Update(Event thisevent)
        {
            await _eventRepository.Update(thisevent);
        }
    }

    
}