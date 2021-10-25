using System;
using System.Linq;
using Event.Uau.Evento.Persistence;
using FluentValidation;

namespace Event.Uau.Evento.Core.Proposta.Commands.RecusarProposta
{
    public class RecusarPropostaCommandValidator : AbstractValidator<RecusarPropostaCommand>
    {
        public RecusarPropostaCommandValidator(EventUauDbContext context)
        {
            RuleFor(i => i.IdEvento)
                .Must(idEvento => context.Eventos.Any(i => i.Id == idEvento))
                .WithMessage("Evento não encontrado.");

            RuleFor(i => i)
                .Must(request => context.Funcionarios.Any(i => i.IdEvento == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado))
                .WithMessage("Não foi encontrada nenhuma proposta para você neste evento.");

            RuleFor(i => i)
                .Must(request => !context.Funcionarios.Any(i => i.IdEvento == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado && i.Evento.Status.Id.Equals("FINALIZADO", StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Não é possível recusar uma proposta após o evento ser encerrado.");

            RuleFor(i => i)
                .Must(request => !context.Eventos.Any(i => i.Id == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado && i.Status.Id.Equals("CANCELADO", StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Não é possível recusar uma proposta de um evento cancelado.");
        }
    }
}
