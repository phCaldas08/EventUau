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

        public DbSet<Domain.Entities.Event> Events { get; set; }
    }
}
