using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class PollDbContext : DbContext
    {
        public PollDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<PollLicense> PollLicense { get; set; }
        public DbSet<PollEvent> Events { get; set; }
        public DbSet<PollOption> EventOptions { get; set; }
        public DbSet<PollVote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PollEvent>(x => x.Property(c => c.Created).HasDefaultValue(DateTime.Now));
            modelBuilder.Entity<PollEvent>(x => x.Property(c => c.Updated).HasDefaultValue(null));
        }
    }
}
