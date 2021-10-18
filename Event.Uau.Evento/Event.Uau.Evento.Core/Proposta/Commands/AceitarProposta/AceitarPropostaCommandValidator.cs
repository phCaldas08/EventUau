using System;
using System.Linq;
using Event.Uau.Evento.Persistence;
using FluentValidation;

namespace Event.Uau.Evento.Core.Proposta.Commands.AceitarProposta
{
    public class AceitarPropostaCommandValidator : AbstractValidator<AceitarPropostaCommand>
    {
        public AceitarPropostaCommandValidator(EventUauDbContext context)
        {
            RuleFor(i => i.IdEvento)
                .Must(idEvento => context.Eventos.Any(i => i.Id == idEvento && i.DataInicio > DateTime.Today.AddHours(-3)))
                .WithMessage("Evento não encontrado.");

            RuleFor(i => i)
                .Must(request => context.Funcionarios.Any(i => i.IdEvento == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado && i.IdStatusContratacao.Equals("PEN", StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Funcionário não encontrado para o evento.");
        }
    }
}
