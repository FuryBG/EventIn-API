using Domain.DtoModels;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPollRepository
    {
        public PollEvent GetPollEventByPollGuid(Guid pollId);
        public PollEvent GetPollEventById(int id);
        public PollEventDto GetPollEventDtoByGuid(Guid pollGuid);
        public List<PollEvent> GetAllPollEventsByUser(int userId);
        public PollEvent UpdatePollEvent(PollEvent pollEvent);
        public void DeletePollEvent(int pollId);
        public PollEvent CreatePollEvent(PollEvent pollEvent);
    }
}
