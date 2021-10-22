using System;
using Event.Uau.Avaliacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Avaliacao.Persistence
{
    public class EventUauDbContext : DbContext
    {
        public EventUauDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
