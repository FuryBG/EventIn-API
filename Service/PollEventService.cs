using Domain.DtoModels;
using Domain.Interfaces;
using Domain.Models;

namespace Service
{
    public class PollEventService : IPollEventService
    {
        private readonly IPollRepository _repository;
        private readonly NetworkService _networkService;
        public PollEventService(IPollRepository pollRepository, NetworkService networkService)
        {
            _repository = pollRepository;
            _networkService = networkService;
        }

        public PollEvent GetPollEventByGuid(Guid pollGuid)
        {
            return _repository.GetPollEventByPollGuid(pollGuid);
        }

        public List<PollEvent> GetAllUserPolls(int userId)
        {
            return _repository.GetAllPollEventsByUser(userId);
        }

        public PollEvent GetPollEventById(int pollId)
        {
            return _repository.GetPollEventById(pollId);
        }

        public PollEventDto GetPollEventDtoByGuid(Guid pollEventGuid)
        {
            string clientIp = _networkService.GetClientIp();
            return _repository.GetPollEventDtoByGuid(pollEventGuid, clientIp);
        }

        public PollEvent CreatePollEvent(PollEvent pollEvent)
        {
            return _repository.CreatePollEvent(pollEvent);
        }

        public PollEvent UpdatePollEvent(PollEvent pollEvent)
        {
            _repository.UpdatePollEvent(pollEvent);
            return pollEvent;
        }

        public void DeletePollEvent(int pollId)
        {
            _repository.DeletePollEvent(pollId);
        }
    }
}
