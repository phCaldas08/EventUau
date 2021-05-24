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
        var eventsFake = new List<Event.Uau.Evento.Domain.Entities.Event>
            {
                new Event.Uau.Evento.Domain.Entities.Event
                {
                    CreateDate = DateTime.Now,
                    Date = DateTime.Today.AddMonths(1),
                    Description = "Teste descricao 1",
                    Name = "Teste nome 1",
                    Key = new Guid("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeee1"),

                },
                new Event.Uau.Evento.Domain.Entities.Event
                {
                    CreateDate = DateTime.Now,
                    Date = DateTime.Today.AddMonths(2),
                    Description = "Teste descricao 2",
                    Name = "Teste nome 2",
                    Key = new Guid("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeee2"),

                },
                new Event.Uau.Evento.Domain.Entities.Event
                {
                    CreateDate = DateTime.Now,
                    Date = DateTime.Today.AddMonths(3),
                    Description = "Teste descricao 3",
                    Name = "Teste nome 3",
                    Key = new Guid("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeee3"),

                },
            };

        Context.Events.AddRange(eventsFake);
        Context.SaveChanges();
        #endregion

    }


    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}