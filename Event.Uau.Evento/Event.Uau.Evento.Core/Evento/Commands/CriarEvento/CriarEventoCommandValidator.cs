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

            /*
            RuleFor(i => i.DataInicio)
                .GreaterThan(DateTime.Now.AddHours(2))
                .WithMessage("O evento deve ser iniciado com pelo menos 2h de antecedência.");
            */

            RuleFor(i => new { i.DataTermino, i.DataInicio })
                .Must(obj => obj.DataTermino >= obj.DataInicio)
                .WithMessage("A data de início não pode ser maior que a data de término do evento.");

        }
    }
}
