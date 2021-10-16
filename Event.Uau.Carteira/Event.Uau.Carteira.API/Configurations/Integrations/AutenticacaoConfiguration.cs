using System;
using Event.Uau.Carteira.Infrastructure.Integracoes.Autenticacao;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Uau.Carteira.API.Configurations.Integrations
{
    public static class AutenticacaoConfiguration
    {
        public static IServiceCollection ConfigureAutenticacaoIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            var urlAutenticacao = configuration.GetSection("UrlAutenticacao").Value;
            services.AddSingleton<IUsuarioIntegracao>(new UsuarioIntegracao(urlAutenticacao));

            return services;
        }

    }
}
