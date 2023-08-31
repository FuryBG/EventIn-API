using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPollEventService
    {
        public PollEvent GetPollEventByGuid(Guid pollId);
        public PollEvent CreatePollEvent(PollEvent pollEvent);
        public void DeletePollEvent(int pollId);
        public PollEvent UpdatePollEvent(PollEvent pollEvent);
    }
}
