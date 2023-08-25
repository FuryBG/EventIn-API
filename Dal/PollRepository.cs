using Domain.Interfaces;
using Domain.Models;

namespace Dal
{
    public class PollRepository : IPollRepository
    {
        public PollEvent DeletePollEvent(int pollId)
        {
            throw new NotImplementedException();
        }

        public List<PollEvent> GetAllPollEventsByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public PollEvent GetPollEventBy(int pollId)
        {
            throw new NotImplementedException();
        }

        public PollEvent UpdatePollEvent(PollEvent pollEvent)
        {
            throw new NotImplementedException();
        }
    }
}
