using System;
using FluentValidation;
using MediatR;

namespace Event.Uau.Evento.Core.Evento.Commands.CriarEvento
{
    public class CriarEventoCommandValidator : AbstractValidator<CriarEventoCommand>
    {
        public CriarEventoCommandValidator()
        {
            RuleFor(i => i.Descricao)
                .MinimumLength(3)
                .MaximumLength(255)
                .WithMessage("A descrição do evento deve ter entre 3 e 255 letras.");

            RuleFor(i => i)
                .Must(i => i.DataTermino > i.DataInicio)
                .WithMessage("A data de início deve ser menor que a data do término.");

            RuleFor(i => i.)
        }
    }
}
