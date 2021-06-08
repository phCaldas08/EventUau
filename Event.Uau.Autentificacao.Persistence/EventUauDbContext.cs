using System;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autentificacao.Persistence
{
    public class EventUauDbContext : DbContext
    {
        public EventUauDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.User> Users { get; set; }
    }
}
