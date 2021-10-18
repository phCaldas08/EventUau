using System;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Persistence
{
    public class EventUauDbContext : DbContext
    {
        public EventUauDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Evento> Eventos { get; set; }
        public DbSet<Domain.Entities.Endereco> Enderecos { get; set; }
        public DbSet<Domain.Entities.FuncionarioEvento> Funcionarios { get; set; }
        public DbSet<Domain.Entities.Status> Status { get; set; }
        public DbSet<Domain.Entities.StatusContratacao> StatusContratacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Evento>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Endereco)
                    .WithOne(e => e.Evento)
                    .HasForeignKey<Domain.Entities.Endereco>(e => e.IdEvento);

                entity.HasMany(e => e.Funcionarios)
                    .WithOne(e => e.Evento)
                    .HasForeignKey(e => e.IdEvento);

                entity.HasOne(e => e.Status)
                    .WithMany(e => e.Eventos)
                    .HasForeignKey(e => e.IdStatus);
            });

            modelBuilder.Entity<Domain.Entities.Endereco>(entity => {
                entity.HasKey(e => e.IdEvento);
            });

            modelBuilder.Entity<Domain.Entities.FuncionarioEvento>(entity => {
                entity.HasKey(e => new { e.IdEvento, e.IdUsuario });

                entity.HasOne(i => i.StatusContratacao)
                    .WithMany(i => i.Funcionarios)
                    .HasForeignKey(i => i.IdStatusContratacao);
            });

            modelBuilder.Entity<Domain.Entities.Status>(entity => {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Domain.Entities.StatusContratacao>(entity => {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Domain.Entities.Curtida>(entity => {
                entity.HasKey(e => new { e.IdEvento, e.IdFuncionario });

                entity.HasOne(e => e.Evento)
                    .WithMany(e => e.Curtidas)
                    .HasForeignKey(e => e.IdEvento);
            });
        }
    }
}
