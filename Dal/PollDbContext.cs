using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class PollDbContext : DbContext
    {
        public PollDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<PollEvent> Events { get; set; }
        public DbSet<PollOption> EventOptions { get; set; }
    }
}
