using System;
using Event.Uau.Evento.Infrastructure.Integracoes.Autenticacao;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Uau.Evento.API.Configurations
{
    public static class Integrations
    {
        public static void ConfigureIntegrations(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IUsuarioIntegracao), new UsuarioIntegracao());
        }
    }
}
