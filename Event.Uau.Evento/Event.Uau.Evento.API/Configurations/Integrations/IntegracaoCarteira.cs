using System;
using Event.Uau.Evento.Infrastructure.Integracoes.Carteira;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Uau.Evento.API.Configurations.Integrations
{
    public static class IntegracaoCarteira
    {
        public static IServiceCollection ConfigureCarteiraIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration.GetSection("UrlCarteira").Value;

            services.AddSingleton<IPropostaIntegracao>(new PropostaIntegracao(url));

            return services;
        }
    }
}
