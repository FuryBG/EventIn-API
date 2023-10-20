using Domain.Interfaces;
using Domain.Models;

namespace Service
{
    public class PollVoteService : IPollVoteService
    {
        private readonly IPollVoteRepository _repository;
        public PollVoteService(IPollVoteRepository pollVoteRepository)
        {
            _repository = pollVoteRepository;
        }

        public PollVote CreateVote(PollVote pollVote)
        {
            return _repository.CreateVote(pollVote);
        }

        public PollVote UpdateVote(PollVote pollVote)
        {
            return _repository.UpdateVote(pollVote);
        }
    }
}
