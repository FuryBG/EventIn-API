using Domain.Interfaces;
using Domain.Models;

namespace Dal
{
    public class AuthPollRepository : IAuthPollRepository
    {
        private readonly PollDbContext _context;
        public AuthPollRepository(PollDbContext context) {
            _context = context;
        }
        public User GetActiveUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Active == true);
        }

        public User GetInactiveUserByActiveHash(string activeHash)
        {
            return _context.Users.FirstOrDefault(u => u.ActivationHash == activeHash);
        }

        public User SaveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
