using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Core.Proposta.Queries.BuscarPropostaPorId;
using Event.Uau.Evento.Persistence;
using Event.Uau.Evento.ViewModel.Evento;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Proposta.Commands.AceitarProposta
{
    public class AceitarPropostaCommandHandler : IRequestHandler<AceitarPropostaCommand, FuncionarioEventoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMediator mediator;

        public AceitarPropostaCommandHandler(EventUauDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<FuncionarioEventoViewModel> Handle(AceitarPropostaCommand request, CancellationToken cancellationToken)
        {
            var proposta = await context.Funcionarios.FirstOrDefaultAsync(i => i.IdEvento == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado);

            proposta.StatusContratacao = await context.StatusContratacoes.FirstOrDefaultAsync(i => i.Id.Equals("AC", StringComparison.CurrentCultureIgnoreCase));

            await context.SaveChangesAsync();

            var query = new BuscaProspostaPorIdQuery { IdEvento = request.IdEvento, IdUsuarioLogado = request.IdUsuarioLogado, Token = request.Token };

            return await mediator.Send(query);
        }
    }
}
