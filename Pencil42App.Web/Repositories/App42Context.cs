using Microsoft.EntityFrameworkCore;
using Pencil42App.Util;
using Pencil42App.Web.Entities;
using Pencil42App.Web.Repositories.Map;

namespace Pencil42App.Web.Repositories
{
    public class App42Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //methode die wordt opgeroepen als hij aan het opstarten is, hoe initialiseren
        {
            Logger.Info(this, "configuring...");
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql("Host=localhost;Database=App42;Username=postgres;Password=pencil42");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new SuggestionMap()); //dit is een andere manier
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new WeekMap());
            modelBuilder.ApplyConfiguration(new BookingMap());
        }
    }


}
