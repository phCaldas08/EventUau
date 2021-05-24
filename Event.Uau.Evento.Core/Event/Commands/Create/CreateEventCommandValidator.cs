using System;
using FluentValidation;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Commands.Create
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
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
