using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.API.Configurations.Integrations;
using Event.Uau.Autenticacao.Core.Helpers;
using Event.Uau.Autenticacao.Core.Helpers.AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Event.Uau.Autenticacao.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Comum.Configuracao.Startup.StartupConfig.ConfigureServices<EventUauDbContext>(
                services,
                new MappingProfile(),
                "EventUauDBAutenticacao",
                typeof(Core.Inicializacao.Commands.InicializacaoCommand));

            services.ConfigureIntegracoesCarteira(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Comum.Configuracao.Startup.StartupConfig.Configure(app, env);
        }
    }
}
