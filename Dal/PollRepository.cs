﻿using Domain.Interfaces;
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
            return _context.Events.Where(e => e.EventGuid == pollId && e.IsDeleted == false).Include(e => e.Options).ThenInclude(e => e.Votes).FirstOrDefault();
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
