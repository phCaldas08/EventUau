using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Carteira.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.PropostaEvento.Commands.FinalizarPropostasEvento
{
    public class FinalizarPropostasEventoCommandHandler : IRequestHandler<FinalizarPropostasEventoCommand, bool>
    {
        private readonly EventUauDbContext context;
        private readonly FinalizarPropostasEventoCommandValidator validator;

        public FinalizarPropostasEventoCommandHandler(EventUauDbContext context, IEventoIntegracao eventoIntegracao)
        {
            this.context = context;
            this.validator = new FinalizarPropostasEventoCommandValidator(context, eventoIntegracao);
        }

        public async Task<bool> Handle(FinalizarPropostasEventoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var propostasEvento = await context.OperacoesEventos.Where(i => i.IdEvento == request.IdEvento).ToListAsync();

            foreach(var proposta in propostasEvento)
            {
                proposta.Recebimento.TipoOperacao = await context.TiposOperacoes.FirstOrDefaultAsync(i => i.Id.Equals("RE", StringComparison.CurrentCultureIgnoreCase));
                proposta.Pagamento.TipoOperacao = await context.TiposOperacoes.FirstOrDefaultAsync(i => i.Id.Equals("PAG", StringComparison.CurrentCultureIgnoreCase));
            }

            await context.SaveChangesAsync();

            return true;
        }
    }
}
