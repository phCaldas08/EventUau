using System;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Avaliacao.Persistence
{
    public class EventUauDbContext : DbContext
    {
        public EventUauDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
