using Kolokwium.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Organiser> Organiser { get; set; }

        public DbSet<EventOrganiser> EventOrganiser { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<ArtistEvent> ArtistEvent { get; set; }

        public DbSet<Artist> Artist { get; set; }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OrganiserEfConfiguration());
            modelBuilder.ApplyConfiguration(new EventOrganiserEfConfiguration());
            modelBuilder.ApplyConfiguration(new EventEfConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistEventEfConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistEfConfiguration());
        }
    }
}
