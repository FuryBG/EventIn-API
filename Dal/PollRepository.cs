using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class PollRepository : IPollRepository
    {
        private readonly PollDbContext _context;
        public PollRepository(PollDbContext context)
        {
            _context = context;
        }
        public void DeletePollEvent(int pollId)
        {
            _context.Events.Where(e => e.Id == pollId).ExecuteUpdate(setter => setter.SetProperty(p => p.IsDeleted, true));
            _context.SaveChanges();
        }

        public List<PollEvent> GetAllPollEventsByUser(int userId)
        {
            return _context.Events.Where(e => e.UserId == userId && e.IsDeleted == false).ToList();
        }

        public PollEvent GetPollEventById(int pollId)
        {
            return _context.Events.FirstOrDefault(e => e.Id == pollId && e.IsDeleted == false);
        }

        public PollEvent UpdatePollEvent(PollEvent pollEvent)
        {
            _context.Events.Update(pollEvent);
            _context.SaveChanges();
            return pollEvent;
        }

        public PollEvent CreatePollEvent(PollEvent pollEvent)
        {
            _context.Events.Add(pollEvent);
            _context.SaveChanges();
            return pollEvent;
        }
    }
}
