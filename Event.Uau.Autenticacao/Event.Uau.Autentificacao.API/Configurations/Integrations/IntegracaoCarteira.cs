using System;
using Event.Uau.Autenticacao.Infrastructure.Integracoes.Carteira;
using Event.Uau.Autenticacao.Infrastructure.Integracoes.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Uau.Autenticacao.API.Configurations.Integrations
{
    public static class IntegracaoCarteira
    {
        public static IServiceCollection ConfigureIntegracoesCarteira(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration.GetSection("UrlCarteira").Value;

            services.AddSingleton<ICarteiraIntegracao>(new CarteiraIntegracao(url));

            return services;
        }
    }
}
