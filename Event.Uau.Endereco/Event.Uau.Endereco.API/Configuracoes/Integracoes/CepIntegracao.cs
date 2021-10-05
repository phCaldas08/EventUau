using System;
using Event.Uau.Endereco.Infrastructure.Cep.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Uau.Endereco.API.Configuracoes.Integracoes
{
    public static class CepIntegracao
    {
        public static IServiceCollection ConfigureCepIntegracao(this IServiceCollection services, IConfiguration configuration)
        {
            var urlCep = configuration.GetSection("UrlCep").Value;

            services.AddSingleton(typeof(ICepIntegracao), new Infrastructure.Cep.Integracao.CepIntegracao(urlCep));

            return services;
        }
    }
}
