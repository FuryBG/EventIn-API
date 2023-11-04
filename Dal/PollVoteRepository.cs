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

        public void DeleteEventVotes(int pollEventId, int userId)
        {
            if(!_context.Events.Any(ev => ev.PollEventId == pollEventId && ev.UserId == userId))
            {
                throw new Exception("You cannot reset votes on events what are not yours!");
            }
            List<PollVote> votes = _context.Votes.Where(vote => vote.PollEventId == pollEventId).ToList();
            _context.Votes.RemoveRange(votes);
            _context.SaveChanges();
        }

        public PollVote UpdateVote(PollVote pollVote)
        {
            _context.Votes.Update(pollVote);
            _context.SaveChanges();
            return pollVote;
        }
    }
}
