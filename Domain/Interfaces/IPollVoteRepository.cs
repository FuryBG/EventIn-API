using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPollVoteRepository
    {
        public PollVote CreateVote(PollVote pollVote, string clientIp);
        public PollVote UpdateVote(PollVote pollVote);
        public void DeleteEventVotes(int pollEventId, int userId);
    }
}
