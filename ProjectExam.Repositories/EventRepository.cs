using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectExam.DbContext;
using ProjectExam.Models;
using ProjectExam.Repositories.Contracts;
using System.Data;

namespace ProjectExam.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Event newevent)
        {
            _context.Events.Add(newevent);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events.ToListAsync();


        }

        public async Task Delete(Guid eventId)
        {
            var user = await Get(eventId);
            _context.Events.Remove(user);
            await _context.SaveChangesAsync();

        }

        public async Task<Event> Get(Guid eventId)
        {
            return await _context.Events.Where(a => a.EventId == eventId).FirstOrDefaultAsync();
        }

        public async Task Update(Event thisevent)
        {
            _context.Events.Update(thisevent);
            await _context.SaveChangesAsync();
        }
    }       
}