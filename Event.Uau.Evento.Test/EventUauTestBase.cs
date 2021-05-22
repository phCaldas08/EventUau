using System;
using Event.Uau.Evento.Persistence;
using Microsoft.EntityFrameworkCore;

public class EventUauTestBase : IDisposable
{
    public readonly EventUauDbContext Context;

    public EventUauTestBase()
    {
        var options = new DbContextOptionsBuilder()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        Context = new EventUauDbContext(options);
    }


    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}