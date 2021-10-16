using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Carteira.Core.Helpers.DadosFake;
using Event.Uau.Carteira.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.Inicializacao.Commands
{
    public class InicializacaoCommandHandler : IRequestHandler<InicializacaoCommand, int>
    {
        private readonly EventUauDbContext context;
        private readonly IMediator mediator;

        public InicializacaoCommandHandler(EventUauDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<int> Handle(InicializacaoCommand request, CancellationToken cancellationToken)
        {
            if (!await context.TiposOperacoes.AnyAsync())
                await mediator.CarregarTiposOperacoes();

            if (!await context.Carteiras.AnyAsync())
                await mediator.CarregarDadosCarteira();

            if (!await context.Operacoes.AnyAsync())
                await mediator.CarregarDadosOperacoes();

            return 0;

        }
    }
}
