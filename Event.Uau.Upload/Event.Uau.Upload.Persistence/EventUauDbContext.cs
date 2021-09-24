using System;
using Event.Uau.Upload.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Upload.Persistence
{
    public class EventUauDbContext : DbContext
    {
        public EventUauDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Arquivo> Arquivos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arquivo>(entity =>
            {
                entity.HasKey(e => new { e.Contexto, e.IdContexto });
            });
        }
    }
}
