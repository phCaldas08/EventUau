using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Carteira.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.PropostaEvento.Commands.CancelarEvento
{
    public class CancelarEventoCommandHandler : IRequestHandler<CancelarEventoCommand, bool>
    {
        private readonly EventUauDbContext context;
        private readonly CancelarEventoCommandValidator validator;

        public CancelarEventoCommandHandler(EventUauDbContext context, IEventoIntegracao eventoIntegracao)
        {
            this.context = context;
            this.validator = new CancelarEventoCommandValidator(eventoIntegracao);
        }

        public async Task<bool> Handle(CancelarEventoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var propostasEvento = await context.OperacoesEventos.Where(i => i.IdEvento == request.IdEvento && i.Pagamento.IdUsuario == request.IdUsuarioLogado).ToListAsync();

            foreach (var propostaEvento in propostasEvento)
            {
                context.OperacoesEventos.Remove(propostaEvento);
                context.Operacoes.Remove(propostaEvento.Pagamento);
                context.Operacoes.Remove(propostaEvento.Recebimento);
            }

            await context.SaveChangesAsync();

            return true;
        }
    }
}
