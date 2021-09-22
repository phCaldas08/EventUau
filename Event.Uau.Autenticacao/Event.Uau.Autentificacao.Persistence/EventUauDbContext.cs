using System;
using Event.Uau.Autenticacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Event.Uau.Autenticacao.Persistence
{
    public class EventUauDbContext : DbContext
    {
        public EventUauDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Parceiro>(entity => {
                entity.HasKey(e => e.IdUsuario);

                entity.HasOne(e => e.Usuario)
                    .WithOne(e => e.Parceiro)
                    .HasForeignKey<Parceiro>(e => e.IdUsuario);
            });
        }
    }
}
