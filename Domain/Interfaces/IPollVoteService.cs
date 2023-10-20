using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPollVoteService
    {
        public PollVote CreateVote(PollVote pollVote);
        public PollVote UpdateVote(PollVote pollVote);
    }
}
