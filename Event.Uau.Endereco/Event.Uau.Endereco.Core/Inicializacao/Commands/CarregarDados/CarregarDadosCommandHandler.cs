using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Endereco.Core.Helpers.DadosFakes;
using Event.Uau.Endereco.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Endereco.Core.Inicializacao.Commands.CarregarDados
{
    public class CarregarDadosCommandHandler : IRequestHandler<CarregarDadosCommand, int>
    {
        private readonly EventUauDbContext context;
        private readonly IMediator mediator;

        public CarregarDadosCommandHandler(EventUauDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<int> Handle(CarregarDadosCommand request, CancellationToken cancellationToken)
        {
            if (!await context.TiposEnderecos.AnyAsync())
                await mediator.CarregarDadosTipoEndereco();

            return 0;
        }
    }
}
