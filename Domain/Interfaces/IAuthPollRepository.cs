using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAuthPollRepository
    {
        public User GetUserByEmail(string email);
        public User SaveUser(User user);
    }
}
