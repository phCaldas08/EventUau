using System;
using System.Linq;
using Event.Uau.Evento.Persistence;
using FluentValidation;

namespace Event.Uau.Evento.Core.Evento.Commands.CancelarEvento
{
    public class CancelarEventoCommandValidator : AbstractValidator<CancelarEventoCommand>
    {
        public CancelarEventoCommandValidator(EventUauDbContext context)
        {
            RuleFor(i => i)
                .Must(request => context.Eventos.Any(i => i.Id == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado))
                .WithMessage("Nenhum evento encontrado.");

            RuleFor(i => i)
                .Must(request => !context.Eventos.Any(i => i.Id == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado && i.DataInicio.AddDays(-2) > DateTime.Now && i.Funcionarios.Any()))
                .WithMessage("A data do evento está muito próxima para ser cancelado.");
        }
    }
}
