using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Avaliacao.Core.Inicializacao.Commands;
using Event.Uau.Avaliacao.Persistence;
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
            return 0;
        }
    }
}