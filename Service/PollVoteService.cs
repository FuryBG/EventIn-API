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
            _repository.CreateVote(pollVote, clientIp);
            if(pollVote.PollVoteId == 0)
            {
                throw new Exception($"Client with IP Address: {clientIp} tried to vote again on Poll with ID: {pollVote.PollEventId}");
            }
            return pollVote;
        }

        public void DeleteEventVotes(int pollEventId)
        {
            int userId = _networkService.GetClientId();
            _repository.DeleteEventVotes(pollEventId, userId);
        }

        public PollVote UpdateVote(PollVote pollVote)
        {
            return _repository.UpdateVote(pollVote);
        }
    }
}
