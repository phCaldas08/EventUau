using System;
using Microsoft.EntityFrameworkCore;
namespace Event.Uau.Autenticacao.Persistence
{
    public class EventUauDbContext : DbContext
    {
        public EventUauDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Usuario> Usuarios { get; set; }
        public DbSet<Domain.Entities.Especialidade> Especialidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Domain.Entities.Especialidade>(entity => {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
