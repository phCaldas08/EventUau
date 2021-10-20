using System;
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
        }
    }
}
