using System;
using System.Collections.Generic;
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
        public DbSet<Especialidade> Especialidades { get; set; }

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

            modelBuilder.Entity<Parceiro>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasOne(e => e.Usuario)
                    .WithOne(e => e.Parceiro)
                    .HasForeignKey<Parceiro>(e => e.IdUsuario);

                entity.HasMany(e => e.Especialidades)
                    .WithMany(e => e.Parceiros)
                    .UsingEntity<ParceiroEspecialidade>(
                        j => j
                            .HasOne(pt => pt.Especialidade)
                            .WithMany(t => t.ParceiroEspecialidades)
                            .HasForeignKey(pt => pt.IdEspecialidade),
                        j => j
                            .HasOne(pt => pt.Parceiro)
                            .WithMany(p => p.ParceiroEspecialidades)
                            .HasForeignKey(pt => pt.IdUsuario)
                    );
            });

            modelBuilder.Entity<Especialidade>(entity => {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<ParceiroEspecialidade>(entity =>
            {
                entity.HasKey(e => new { e.IdEspecialidade, e.IdUsuario });

                entity.HasOne(e => e.Parceiro)
                    .WithMany(e => e.ParceiroEspecialidades)
                    .HasForeignKey(e => e.IdUsuario);

                entity.HasOne(e => e.Especialidade)
                    .WithMany(e => e.ParceiroEspecialidades)
                    .HasForeignKey(e => e.IdEspecialidade);
            });
        }
    }
}
