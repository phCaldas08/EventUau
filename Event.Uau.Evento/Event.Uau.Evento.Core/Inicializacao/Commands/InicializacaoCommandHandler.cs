using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Helpers.DadosFakes;
using Event.Uau.Evento.Core.Inicializacao.Commands;
using Event.Uau.Evento.Persistence;
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
            if (!await context.Eventos.AnyAsync())
                await mediator.CarregarEventosAsync();

            return 0;
        }
    }
}
