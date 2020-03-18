using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using sm_coding_challenge.Domain.Models;
namespace sm_coding_challenge.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<DownloadTracker> DownloadTrackers {get; set;}
        public DbSet<Player> Players {get; set;}
        public DbSet<Rushing> Rushings {get; set;}
        public DbSet<Passing> Passings {get; set;}
        public DbSet<Receiving> Receivings {get; set;}
         public DbSet<Kicking> Kickings {get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}