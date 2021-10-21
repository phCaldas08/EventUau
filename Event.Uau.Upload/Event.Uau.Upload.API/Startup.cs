using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Upload.Core.AutoMapper;
using Event.Uau.Upload.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Event.Uau.Upload.API
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
                "EventUauDBUpload",
                typeof(Core.Arquivo.Commands.DeletarArquivo.DeletarArquivoCommand));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Comum.Configuracao.Startup.StartupConfig.Configure(app, env);
        }
    }
}
