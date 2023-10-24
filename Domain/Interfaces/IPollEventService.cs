using Domain.DtoModels;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPollEventService
    {
        public List<PollEvent> GetAllUserPolls(int userId);
        public PollEvent GetPollEventByGuid(Guid pollGuid);
        public PollEvent GetPollEventById(int pollId);
        public PollEventDto GetPollEventDtoByGuid(Guid pollEventGuid);
        public PollEvent CreatePollEvent(PollEvent pollEvent);
        public PollEvent UpdatePollEvent(PollEvent pollEvent);
        public void DeletePollEvent(int pollId);
    }
}
