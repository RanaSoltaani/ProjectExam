using ProjectExam.Models;

namespace ProjectExam.Services.Contracts
{
    public interface IEventService
    {
        public Task Add(Event newevent);

        public Task<IEnumerable<Event>> GetAll();

        public Task Update(Event thisevent);

        public Task Delete(Guid eventId);

        public Task<Event> Get(Guid eventId);


    }
}