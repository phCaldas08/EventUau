using System;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Persistence
{
    public class EventUauDbContext : DbContext
    {
        public EventUauDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Carteira> Carteiras { get; set; }
        public DbSet<Domain.Entities.Operacao> Operacoes { get; set; }
        public DbSet<Domain.Entities.TipoOperacao> TiposOperacoes { get; set; }
        public DbSet<Domain.Entities.OperacaoEvento> OperacoesEventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Carteira>(entity => {
                entity.HasKey(i => i.IdUsuario);

                entity.HasMany(i => i.Operacoes)
                    .WithOne(i => i.Carteira)
                    .HasForeignKey(i => i.IdUsuario);
            });

            modelBuilder.Entity<Domain.Entities.Operacao>(entity => {
                entity.HasKey(i => i.Id);

                entity.HasOne(i => i.OperacaoEventoPagador)
                    .WithOne(i => i.Pagamento)
                    .HasForeignKey<Domain.Entities.OperacaoEvento>(i => i.IdPagador);

                entity.HasOne(i => i.OperacaoEventoRecebedor)
                    .WithOne(i => i.Recebimento)
                    .HasForeignKey<Domain.Entities.OperacaoEvento>(i => i.IdRecebedor);

                entity.HasOne(i => i.TipoOperacao)
                    .WithMany(i => i.Operacoes)
                    .HasForeignKey(i => i.IdTipoOperacao);
            });

            modelBuilder.Entity<Domain.Entities.TipoOperacao>(entity => {
                entity.HasKey(i => i.Id);

            });

            modelBuilder.Entity<Domain.Entities.OperacaoEvento>(entity => {
                entity.HasKey(i => new { i.IdEvento, i.IdPagador, i.IdRecebedor });
            });
        }
    }
}
