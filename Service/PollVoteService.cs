using Domain.Interfaces;
using Domain.Models;

namespace Service
{
    public class PollVoteService : IPollVoteService
    {
        private readonly IPollVoteRepository _repository;
        private readonly NetworkService _networkService;
        public PollVoteService(IPollVoteRepository pollVoteRepository, NetworkService networkService)
        {
            _repository = pollVoteRepository;
            _networkService = networkService;
        }

        public PollVote CreateVote(PollVote pollVote)
        {
            string clientIp = _networkService.GetClientIp();
            pollVote.IpAddress = clientIp;
            return _repository.CreateVote(pollVote, clientIp);
        }

        public PollVote UpdateVote(PollVote pollVote)
        {
            return _repository.UpdateVote(pollVote);
        }
    }
}
