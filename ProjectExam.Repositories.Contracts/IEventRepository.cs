using ProjectExam.Models;
using System.Data;

namespace ProjectExam.Repositories.Contracts
{
    public interface IEventRepository
    {
        public Task Add(Event newevent);

        public Task<IEnumerable<Event>> GetAll();

        public Task Update(Event thisevent);

        public Task Delete(Guid eventId);

        public Task<Event> Get(Guid eventId);

    }
}
