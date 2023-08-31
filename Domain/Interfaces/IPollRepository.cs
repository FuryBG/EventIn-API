using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPollRepository
    {
        public PollEvent GetPollEventByPollGuid(Guid pollId);
        public PollEvent UpdatePollEvent(PollEvent pollEvent);
        public void DeletePollEvent(int pollId);
        public List<PollEvent> GetAllPollEventsByUser(int userId);
        public PollEvent CreatePollEvent(PollEvent pollEvent);
    }
}
