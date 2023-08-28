using Domain.Interfaces;
using Domain.Models;

namespace Service
{
    public class PollEventService : IPollEventService
    {
        private readonly IPollRepository _repository;
        public PollEventService(IPollRepository pollRepository)
        {
            _repository = pollRepository;
        }

        public PollEvent GetPollEventById(int pollId)
        {
            return _repository.GetPollEventById(pollId);
        }

        public PollEvent CreatePollEvent(PollEvent pollEvent)
        {
            return _repository.CreatePollEvent(pollEvent);
        }

        public void DeletePollEvent(int pollId)
        {
            _repository.DeletePollEvent(pollId);
        }

        public PollEvent UpdatePollEvent(PollEvent pollEvent)
        {
            _repository.UpdatePollEvent(pollEvent);
            return pollEvent;
        }
    }
}
