using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPollRepository
    {
        public PollEvent GetPollEventBy(int pollId);
        public PollEvent UpdatePollEvent(PollEvent pollEvent);
        public PollEvent DeletePollEvent(int pollId);
        public List<PollEvent> GetAllPollEventsByUser(int userId);
    }
}
