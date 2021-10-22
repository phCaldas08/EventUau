using System;
using Event.Uau.Carteira.Infrastructure.Integracoes.Evento;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Uau.Carteira.API.Configurations.Integrations
{
    public static class EventoConfiguration
    {
        public static IServiceCollection ConfigureEventoIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration.GetSection("UrlEvento").Value;

            services.AddSingleton<IEventoIntegracao>(new EventoIntegracao(url));

            return services;
        }
    }
}
