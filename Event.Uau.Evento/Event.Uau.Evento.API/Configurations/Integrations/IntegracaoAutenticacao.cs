using System;
using Event.Uau.Evento.Infrastructure.Integracoes.Autenticacao;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Uau.Evento.API.Configurations.Integrations
{
    public static class IntegracaoAutenticacao
    {
        public static IServiceCollection ConfigureIntegracoesAutenticacao(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration.GetSection("UrlAutenticacao").Value;

            services.AddSingleton<IUsuarioIntegracao>(new UsuarioIntegracao(url));
            services.AddSingleton<IParceiroIntegracao>(new ParceiroIntegracao(url));
            services.AddSingleton<IEspecialidadeIntegracao>(new EspecialidadeIntegracao(url));

            return services;
        }
    }
}
