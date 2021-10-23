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
            RuleFor(i => new { i.IdEvento, i.IdUsuarioLogado })
                .Must(obj => context.Eventos.Any(i => i.Id == obj.IdEvento
                                                    //&& i.DataInicio.AddHours(-2) > DateTime.Now
                                                    && (i.Status.Id.Equals("CRIADO", StringComparison.CurrentCultureIgnoreCase) || i.Status.Id.Equals("CONTRATANDO", StringComparison.CurrentCultureIgnoreCase))))
                .WithMessage("Nenhum evento encontrado.");

            RuleFor(i => i)
                .Must(request => context.Funcionarios.Any(i => i.IdEvento == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado && i.IdStatusContratacao.Equals("PEN", StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Funcionário não encontrado para o evento.");
        }
    }
}
