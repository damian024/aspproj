using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class EventsDbContext : DbContext
    {
        public EventsDbContext(DbContextOptions<EventsDbContext> options): base(options)
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventSponsor> EventSponsors { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>().ToTable("Branch");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Sponsor>().ToTable("Sponsor");
            modelBuilder.Entity<EventSponsor>().ToTable("EventSponsor");
        }
    }
}
