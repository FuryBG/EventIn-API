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
            _context.Events.Where(e => e.PollEventId == pollId).ExecuteUpdate(setter => setter.SetProperty(p => p.IsDeleted, true));
            _context.SaveChanges();
        }

        public List<PollEvent> GetAllPollEventsByUser(int userId)
        {
            return _context.Events.Where(e => e.UserId == userId && e.IsDeleted == false).ToList();
        }

        public PollEvent GetPollEventByPollGuid(Guid pollId)
        {
            //TODO CREATE DTO MODEL
            //var test = _context.Events.Select(e => new
            //{
            //    e.PollEventId,
            //    e.EventGuid,
            //    Options = _context.EventOptions.Select(o => new
            //    {
            //        o.PollEventId,
            //        o.PollOptionId,
            //        o.Value,
            //        o.Type,
            //        Percentage = (100 / _context.Votes.Where(v => v.PollEventId == e.PollEventId).Count()) * (_context.Votes.Where(v => v.PollEventId == e.PollEventId && o.PollOptionId == v.PollOptionId).Count()),
            //    }).Where(o => o.PollEventId == e.PollEventId).ToList()
            //}).Where(e => e.EventGuid == pollId).FirstOrDefault();
            return _context.Events.Where(e => e.EventGuid == pollId && e.IsDeleted == false).Include(e => e.Options).ThenInclude(e => e.Votes).AsSplitQuery().FirstOrDefault();
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

        public PollEvent GetPollEventById(int pollEventId)
        {
            return _context.Events.Where(e => e.PollEventId == pollEventId && e.IsDeleted == false).Include(e => e.Options).FirstOrDefault();
        }
    }
}
