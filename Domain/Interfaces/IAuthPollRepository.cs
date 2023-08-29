using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAuthPollRepository
    {
        public User GetActiveUserByEmail(string email);
        public User GetInactiveUserByActiveHash(string activeHash);
        public User UpdateUser(User user);
        public User SaveUser(User user);
    }
}
