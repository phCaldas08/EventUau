using System;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Endereco.Persistence
{
    public class EventUauDbContext : DbContext
    {
        public EventUauDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.TipoEndereco> TiposEnderecos { get; set; }
        public DbSet<Domain.Entities.Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Endereco>(entity =>
            {
                entity.HasOne(e => e.TipoEndereco)
                    .WithMany(e => e.Enderecos)
                    .HasForeignKey(e => e.IdTipoEndereco);
            });

        }
    }
}
