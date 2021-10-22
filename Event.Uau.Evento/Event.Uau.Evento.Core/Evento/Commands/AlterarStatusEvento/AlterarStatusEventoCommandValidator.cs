using System;
using Event.Uau.Evento.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Evento.Commands.AlterarStatusEvento
{
    public class AlterarStatusEventoCommandValidator : AbstractValidator<AlterarStatusEventoCommand>
    {
        public AlterarStatusEventoCommandValidator(EventUauDbContext context)
        {
            RuleFor(i => i)
                .MustAsync((request, c) => context.Eventos.AnyAsync(i => i.Id == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado))
                .WithMessage("Evento não encontrado.");
        }
    }
}
