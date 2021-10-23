using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Carteira.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.PropostaEvento.Commands.RecusarPropostaEvento
{
    public class RecusarPropostaEventoCommandHandler : IRequestHandler<RecusarPropostaEventoCommand, bool>
    {
        private readonly EventUauDbContext context;
        private readonly RecusarPropostaEventoCommandValidator validator;

        public RecusarPropostaEventoCommandHandler(EventUauDbContext context, IEventoIntegracao eventoIntegracao)
        {
            this.context = context;
            this.validator = new RecusarPropostaEventoCommandValidator(context, eventoIntegracao);
        }

        public async Task<bool> Handle(RecusarPropostaEventoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var propostaEvento = await context.OperacoesEventos.FirstOrDefaultAsync(i => i.IdEvento == request.IdEvento && i.Recebimento.IdUsuario == request.IdUsuarioLogado);

            context.OperacoesEventos.Remove(propostaEvento);
            context.Operacoes.Remove(propostaEvento.Pagamento);
            context.Operacoes.Remove(propostaEvento.Recebimento);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
