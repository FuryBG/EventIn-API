using Domain.DtoModels;
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
            return _repository.GetPollEventDtoByGuid(pollEventGuid);
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
