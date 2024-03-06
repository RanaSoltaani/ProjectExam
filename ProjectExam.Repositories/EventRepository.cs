using ProjectExam.DbContext;
using ProjectExam.Models;
using ProjectExam.Repositories.Contracts;

namespace ProjectExam.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context) 
        {
            _context = context;
        }

    

    }
}