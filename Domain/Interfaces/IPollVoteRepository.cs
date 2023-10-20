using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPollVoteRepository
    {
        public PollVote CreateVote(PollVote pollVote);
        public PollVote UpdateVote(PollVote pollVote);
    }
}
