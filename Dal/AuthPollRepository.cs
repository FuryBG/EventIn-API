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
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User SaveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
