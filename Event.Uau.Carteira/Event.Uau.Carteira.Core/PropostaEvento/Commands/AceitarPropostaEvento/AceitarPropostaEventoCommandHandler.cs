using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Carteira.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.PropostaEvento.Commands.AceitarPropostaEvento
{
    public class AceitarPropostaEventoCommandHandler : IRequestHandler<AceitarPropostaEventoCommand, bool>
    {
        private readonly EventUauDbContext context;
        private readonly AceitarPropostaEventoCommandValidator validator;

        public AceitarPropostaEventoCommandHandler(EventUauDbContext context, IEventoIntegracao eventoIntegracao)
        {
            this.context = context;
            this.validator = new AceitarPropostaEventoCommandValidator(context, eventoIntegracao);
        }

        public async Task<bool> Handle(AceitarPropostaEventoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var propostaParceiro = await context.OperacoesEventos.FirstOrDefaultAsync(i => i.IdEvento == request.IdEvento && i.Recebimento.IdUsuario == request.IdUsuarioLogado);

            propostaParceiro.Recebimento.TipoOperacao = await context.TiposOperacoes.FirstOrDefaultAsync(i => i.Id.Equals("RPE", StringComparison.CurrentCultureIgnoreCase));

            await context.SaveChangesAsync();

            return true;
        }
    }
}
