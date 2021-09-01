using System;
using System.Collections.Generic;
using AutoMapper;
using Event.Uau.Evento.Core.Helpers.AutoMapper;
using Event.Uau.Evento.Persistence;
using Microsoft.EntityFrameworkCore;

public class EventUauTestBase : IDisposable
{
    public readonly EventUauDbContext Context;
    public readonly IMapper mapper;

    public EventUauTestBase()
    {
        var options = new DbContextOptionsBuilder()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        Context = new EventUauDbContext(options);


        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        mapper = mapperConfig.CreateMapper();


        #region Preparar dados fakes
        
        #endregion

    }


    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}