using Domain.DtoModels;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dal
{
    public class PollRepository : IPollRepository
    {
        private readonly PollDbContext _context;
        public PollRepository(PollDbContext context)
        {
            _context = context;
        }

        public List<PollEvent> GetAllPollEventsByUser(int userId)
        {
            return _context.Events.Where(e => e.UserId == userId && e.IsDeleted == false).ToList();
        }

        public PollEvent GetPollEventByPollGuid(Guid pollId)
        {
            return _context.Events.Where(e => e.EventGuid == pollId && e.IsDeleted == false).Include(e => e.Options).ThenInclude(e => e.Votes).AsSplitQuery().FirstOrDefault();
        }
        public PollEvent GetPollEventById(int pollEventId)
        {
            return _context.Events.Where(e => e.PollEventId == pollEventId && e.IsDeleted == false).Include(e => e.Options).FirstOrDefault();
        }
        public PollEventDto GetPollEventDtoByGuid(Guid pollGuid)
        {
            return _context.Events.Select(e =>
                new PollEventDto()
                {
                    EventGuid = e.EventGuid,
                    Title = e.Title,
                    UserId = e.UserId,
                    Created = e.Created,
                    IsActive = e.IsActive,
                    VotesCount = _context.Votes.Where(v => v.PollEventId == e.PollEventId).Count(),
                    Options = _context.EventOptions.Select(o => new PollOptionDto()
                    {
                        PollEventId = o.PollEventId,
                        PollOptionId = o.PollOptionId,
                        Type = o.Type,
                        Value = o.Value,
                        Precentage = (int)Math.Ceiling(100 / (double)_context.Votes.Where(v => v.PollEventId == e.PollEventId).Count() * _context.Votes.Where(v => v.PollEventId == e.PollEventId && o.PollOptionId == v.PollOptionId).Count())
                    }).Where(o => o.PollEventId == e.PollEventId).ToList()
                }).Where(e => e.EventGuid == pollGuid).First();
        }

        public PollEvent CreatePollEvent(PollEvent pollEvent)
        {
            _context.Events.Add(pollEvent);
            _context.SaveChanges();
            return pollEvent;
        }

        public PollEvent UpdatePollEvent(PollEvent pollEvent)
        {
            _context.Events.Update(pollEvent);
            _context.SaveChanges();
            return pollEvent;
        }

        public void DeletePollEvent(int pollId)
        {
            _context.Events.Where(e => e.PollEventId == pollId).ExecuteUpdate(setter => setter.SetProperty(p => p.IsDeleted, true));
            _context.SaveChanges();
        }
    }
}
