using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Endereco.API.Configuracoes.Integracoes;
using Event.Uau.Endereco.Core.Helpers.AutoMapper;
using Event.Uau.Endereco.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Event.Uau.Endereco.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Comum.Configuracao.Startup.StartupConfig.ConfigureServices<EventUauDbContext>(
                services,
                new MappingProfile(),
                "EnderecoDb",
                typeof(Core.Inicializacao.Commands.CarregarDados.CarregarDadosCommand));

            services.ConfigureCepIntegracao(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Comum.Configuracao.Startup.StartupConfig.Configure(app, env);
        }
    }
}
