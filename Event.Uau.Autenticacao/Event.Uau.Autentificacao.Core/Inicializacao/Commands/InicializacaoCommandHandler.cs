using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Autenticacao.Core.Helpers.DadosFakes;
using Event.Uau.Autenticacao.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autenticacao.Core.Inicializacao.Commands
{
    public class InicializacaoCommandHandler : IRequestHandler<InicializacaoCommand, int>
    {
        private readonly IMediator mediator;
        private readonly EventUauDbContext context;

        public InicializacaoCommandHandler(EventUauDbContext context, IMediator mediator)
        {
            this.mediator = mediator;
            this.context = context;
        }

        public async Task<int> Handle(InicializacaoCommand request, CancellationToken cancellationToken)
        {
            if(!await context.Usuarios.AnyAsync())
                await mediator.CarregarUsuariosAsync();

            if (!await context.Especialidades.AnyAsync())
                await mediator.CarregarEspecialidadesAsync();

            if (!await context.Parceiros.AnyAsync())
                await mediator.CarregarParceirosAsync();               
            

            return 0;
        }
    }
}
