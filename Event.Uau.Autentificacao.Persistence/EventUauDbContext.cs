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

        public DbSet<Domain.Entities.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.User>(entity =>
            {
                entity.HasKey(e => e.UserName);
            });
        }
    }
}
