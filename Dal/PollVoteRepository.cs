using Domain.Interfaces;
using Domain.Models;

namespace Dal
{
    public class PollVoteRepository : IPollVoteRepository
    {
        private readonly PollDbContext _context;
        public PollVoteRepository(PollDbContext context)
        {
            _context = context;
        }

        public PollVote CreateVote(PollVote pollVote, string clientIp)
        {
            if(!_context.Votes.Any(v => v.IpAddress == clientIp))
            {
                _context.Votes.Add(pollVote);
                _context.SaveChanges();
            }
            return pollVote;
        }

        public PollVote UpdateVote(PollVote pollVote)
        {
            _context.Votes.Update(pollVote);
            _context.SaveChanges();
            return pollVote;
        }
    }
}
