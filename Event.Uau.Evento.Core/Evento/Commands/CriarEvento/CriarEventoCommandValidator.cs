using System;
using FluentValidation;
using MediatR;

namespace Event.Uau.Evento.Core.Evento.Commands.CriarEvento
{
    public class CriarEventoCommandValidator : AbstractValidator<CriarEventoCommand>
    {
        public CriarEventoCommandValidator()
        {
            RuleFor(x => x.Date)
                .GreaterThan(DateTime.Now);

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
