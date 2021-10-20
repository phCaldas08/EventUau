using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Helpers.DadosFakes;
using Event.Uau.Evento.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Inicializacao.Commands
{
    public class InicializacaoCommandHandler : IRequestHandler<InicializacaoCommand, int>
    {
        private static bool rodado = false;

        private readonly EventUauDbContext context;
        private readonly IMediator mediator;

        public InicializacaoCommandHandler(EventUauDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<int> Handle(InicializacaoCommand request, CancellationToken cancellationToken)
        {
            if (rodado) return 0;

            if (!await context.StatusContratacoes.AnyAsync())
                await mediator.CarregarDadosStatusContratacao();

            if (!await context.Status.AnyAsync())
                await mediator.CarregarDadosStatus();


            rodado = true;

            return 0;
        }
    }
}
