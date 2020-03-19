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

            builder.Entity<Player>().ToTable("Players");
            builder.Entity<Player>().HasKey(p => p.Id);
            //builder.Entity<Player>().HasKey(p => p.PlayerId);
            builder.Entity<Player>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Player>().Property(p => p.PlayerId).IsRequired();
            builder.Entity<Player>().Property(p => p.Name).IsRequired();
            builder.Entity<Player>().Property(p => p.Position).IsRequired();
            builder.Entity<Player>().HasData
            (
               new Player { Id = 100, PlayerId = "8f22eb36-5282-407a-b6f9-f9b62e5f7318", Name = "Charlie Whitehurs", Position = "QB" }, // Id set manually due to in-memory provider
               new Player { Id = 101, PlayerId = "2fda010a-8c62-4c07-b601-4ba03f57e6af", Name = "Alex Smith", Position = "RB" },
               new Player { Id = 102, PlayerId = "ed29fd68-0d5d-4636-8010-31436a78c9c6", Name = "Jamaal Charles", Position = "K" }
            );
            

            builder.Entity<Kicking>().ToTable("Kickings");
            builder.Entity<Kicking>().HasKey(p => p.Id);
            builder.Entity<Kicking>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Kicking>().Property(p => p.PlayerId).IsRequired();
            builder.Entity<Kicking>().Property(p => p.EntryId).IsRequired();
            builder.Entity<Kicking>().Property(p => p.FldGoalsMade).IsRequired();
            builder.Entity<Kicking>().Property(p => p.FldGoalsAtt).IsRequired();
            builder.Entity<Kicking>().Property(p => p.ExtraPtMade).IsRequired();
            builder.Entity<Kicking>().Property(p => p.ExtraPtAtt).IsRequired();
            builder.Entity<Kicking>().HasData
            (
               new Kicking { Id = 100, PlayerId = "8f22eb36-5282-407a-b6f9-f9b62e5f7318", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", FldGoalsMade = 10,  FldGoalsAtt = 3, ExtraPtMade = 2, ExtraPtAtt = 5}, 
               new Kicking { Id = 101, PlayerId = "2fda010a-8c62-4c07-b601-4ba03f57e6af", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", FldGoalsMade = 4,  FldGoalsAtt = 4, ExtraPtMade = 3, ExtraPtAtt = 3}, 
               new Kicking { Id = 104, PlayerId = "ed29fd68-0d5d-4636-8010-31436a78c9c6", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", FldGoalsMade = 1,  FldGoalsAtt = 2, ExtraPtMade = 3, ExtraPtAtt = 3} 
               
            );


            builder.Entity<Passing>().ToTable("Passings");
            builder.Entity<Passing>().HasKey(p => p.Id);
            builder.Entity<Passing>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Passing>().Property(p => p.PlayerId).IsRequired();
            builder.Entity<Passing>().Property(p => p.EntryId).IsRequired();
            builder.Entity<Passing>().Property(p => p.Yds).IsRequired();
            builder.Entity<Passing>().Property(p => p.Att).IsRequired();
            builder.Entity<Passing>().Property(p => p.Tds).IsRequired();
            builder.Entity<Passing>().Property(p => p.Cmp).IsRequired();
            builder.Entity<Passing>().Property(p => p.Int).IsRequired();
            builder.Entity<Passing>().HasData
            (
               new Passing { Id = 100, PlayerId = "8f22eb36-5282-407a-b6f9-f9b62e5f7318", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", Yds = 177, Att = 23, Tds = 1, Cmp=12,Int = 1  }, 
               new Passing { Id = 105, PlayerId = "2fda010a-8c62-4c07-b601-4ba03f57e6af", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", Yds = 43, Att = 0, Tds = 21, Cmp=12,Int = 2}, 
               new Passing { Id = 107, PlayerId = "ed29fd68-0d5d-4636-8010-31436a78c9c6", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", Yds = 248, Att = 26, Tds = 3, Cmp=20,Int = 0 } 
               
            );
            
            builder.Entity<Receiving>().ToTable("Receivings");
            builder.Entity<Receiving>().HasKey(p => p.Id);
            builder.Entity<Receiving>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Receiving>().Property(p => p.PlayerId).IsRequired();
            builder.Entity<Receiving>().Property(p => p.EntryId).IsRequired();
            builder.Entity<Receiving>().Property(p => p.Yds).IsRequired();
            builder.Entity<Receiving>().Property(p => p.Tds).IsRequired();
            builder.Entity<Receiving>().Property(p => p.Rec).IsRequired();

            builder.Entity<Receiving>().HasData
            (
               new Receiving { Id = 100, PlayerId = "8f22eb36-5282-407a-b6f9-f9b62e5f7318", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", Yds = 20,  Tds = 1, Rec = 1  }, 
               new Receiving { Id = 110, PlayerId = "2fda010a-8c62-4c07-b601-4ba03f57e6af", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", Yds = 7, Rec = 1, Tds = 21}, 
               new Receiving { Id = 120, PlayerId = "ed29fd68-0d5d-4636-8010-31436a78c9c6", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", Yds = 20,  Tds = 3,Rec = 1  } 
               
            );

            builder.Entity<Rushing>().ToTable("Rushings");
            builder.Entity<Rushing>().HasKey(p => p.Id);
            builder.Entity<Rushing>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Rushing>().Property(p => p.PlayerId).IsRequired();
            builder.Entity<Rushing>().Property(p => p.EntryId).IsRequired();
            builder.Entity<Rushing>().Property(p => p.Yds).IsRequired();
            builder.Entity<Rushing>().Property(p => p.Att).IsRequired();
            builder.Entity<Rushing>().Property(p => p.Tds).IsRequired();
            builder.Entity<Rushing>().Property(p => p.Fum).IsRequired();
            builder.Entity<Rushing>().HasData
            (
               new Rushing { Id = 100, PlayerId = "8f22eb36-5282-407a-b6f9-f9b62e5f7318", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", Yds = 177, Att = 23, Tds = 1, Fum=12 }, 
               new Rushing { Id = 189, PlayerId = "8f22eb36-5282-407a-b6f9-f9b62e5f7318", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", Yds = 180, Att = 25, Tds = 2, Fum=15 }, 
               new Rushing { Id = 105, PlayerId = "2fda010a-8c62-4c07-b601-4ba03f57e6af", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", Yds = 43, Att = 0, Tds = 21, Fum = 0}, 
               new Rushing { Id = 107, PlayerId = "ed29fd68-0d5d-4636-8010-31436a78c9c6", EntryId = "9ecf8040-10f9-4a5c-92da-1b4d77bd67602014REG4ki", Yds = 248, Att = 26, Tds = 3, Fum = 1} 
               
            );

        }
    }
}