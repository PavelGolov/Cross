using Cross.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cross.DAL
{
    public class CrossContext : IdentityDbContext<User,Role,int>
    {
        public CrossContext(DbContextOptions<CrossContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }

        public DbSet<Race> Races { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<RaceType> RaceTypes { get; set; }

        public DbSet<RaceStatus> RaceStatuses { get; set; }

        public DbSet<Venue> Venues { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Action> Actions { get; set; }

        public DbSet<ActionStatus> ActionStatuses { get; set; }

        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<ActionStatus>()
                .HasOne(e => e.Action)
                .WithMany(e => e.ActionStatuses)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Race>()
                .HasOne(e => e.Track)
                .WithMany(e => e.Races)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Request>()
                .HasOne(e => e.Car)
                .WithMany(e => e.Requests)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Car>()
                .HasOne(e => e.RaceType)
                .WithMany(e => e.Cars)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
