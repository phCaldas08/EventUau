using System;
using AutoMapper;
using Event.Uau.Autenticacao.Core.Helpers.AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using Event.Uau.Autenticacao.Test.Configuracoes.DadosTeste;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autenticacao.Test.Configuracoes
{
    public class EventUauAutenticacaoTestBase : IDisposable
    {
        public readonly EventUauDbContext context;
        public readonly IMapper mapper;

        public EventUauAutenticacaoTestBase()
        {
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new EventUauDbContext(options);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mapperConfig.CreateMapper();

            context.CarregarUsuarios();

        }


        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
