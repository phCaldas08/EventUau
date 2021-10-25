using System;
using System.Linq;
using Event.Uau.Evento.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Evento.Commands.FinalizarEvento
{
    public class FinalizarEventoCommandValidator : AbstractValidator<FinalizarEventoCommand>
    {
        public FinalizarEventoCommandValidator(EventUauDbContext context)
        {
            RuleFor(i => i)
                .MustAsync((request, c) => context.Eventos.AnyAsync(i => i.Id == request.IdEvento
                            //&& i.DataInicio.AddHours(1) <= DateTime.Now
                            && (i.Status.Id.Equals("CRIADO", StringComparison.CurrentCultureIgnoreCase) || i.Status.Id.Equals("CONTRATANDO", StringComparison.CurrentCultureIgnoreCase))))
                .WithMessage("Só é possível encerrar um evento no minímo uma hora depois do horário de início.");

            RuleFor(i => i)
                .Must(request => !context.Eventos.Any(i => i.Id == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado && i.Status.Id.Equals("CANCELADO", StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Não é possível finalizar um evento cancelado.");
        }
    }
}
